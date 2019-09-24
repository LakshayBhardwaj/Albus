﻿
using Microsoft.ProjectOxford.Face;
using Microsoft.ProjectOxford.Face.Contract;
using ClientContract = Microsoft.ProjectOxford.Face.Contract;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Windows.Media;
using System.Threading;
using System.Windows.Threading;
using System.Windows.Media.Imaging;

namespace WebRole1.Controllers
{
    public class ValuesController : ApiController
    {

        private static string sampleGroupId = Guid.NewGuid().ToString();

        private ObservableCollection<Person> _persons = new ObservableCollection<Person>();

        private ObservableCollection<Face> _faces = new ObservableCollection<Face>();

        private ImageSource _selectedFile;

        private int _maxConcurrentProcesses;

        public event PropertyChangedEventHandler PropertyChanged;

        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public async void Get(int id)
        {
            bool groupExists = false;


            string subscriptionKey = "";
            string endpoint = "";

            var faceServiceClient = new FaceServiceClient(subscriptionKey, endpoint);
            System.Diagnostics.Debug.WriteLine("---------Hiiiii--------");

            try
            {
                System.Diagnostics.Debug.WriteLine("Request: Group {0} will be used to build a person database. Checking whether the group exists.", this.GroupId);

                await faceServiceClient.GetLargePersonGroupAsync(this.GroupId);
                groupExists = true;
                System.Diagnostics.Debug.WriteLine("Response: Group {0} exists.", this.GroupId);
            }
            catch (FaceAPIException ex)
            {
                if (ex.ErrorCode != "LargePersonGroupNotFound")
                {
                    System.Diagnostics.Debug.WriteLine("Response: {0}. {1}", ex.ErrorCode, ex.ErrorMessage);
                    return;
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("Response: Group {0} did not exist previously.", this.GroupId);
                }
            }

            if (groupExists)
            {
                await faceServiceClient.DeleteLargePersonGroupAsync(this.GroupId);
                this.GroupId = Guid.NewGuid().ToString();
            }

            const int SuggestionCount = 15;

            Persons.Clear();
            TargetFaces.Clear();
            SelectedFile = null;
            // IdentifyButton.IsEnabled = false;

            System.Diagnostics.Debug.WriteLine("Request: Creating group \"{0}\"", this.GroupId);
            try
            {
                await faceServiceClient.CreateLargePersonGroupAsync(this.GroupId, this.GroupId);
                System.Diagnostics.Debug.WriteLine("Response: Success. Group \"{0}\" created", this.GroupId);
            }
            catch (FaceAPIException ex)
            {
                System.Diagnostics.Debug.WriteLine("Response: {0}. {1}", ex.ErrorCode, ex.ErrorMessage);
                return;
            }


            int processCount = 0;
            bool forceContinue = false;

            System.Diagnostics.Debug.WriteLine("Request: Preparing faces for identification, detecting faces in chosen folder.");

            // Enumerate top level directories, each directory contains one person's images
            int invalidImageCount = 0;

            foreach (var dir in System.IO.Directory.EnumerateDirectories("D:/Development/Cognitive-Face-Windows-master/Cognitive-Face-Windows-master/Data/PersonGroup"))
            {
                var tasks = new List<Task>();
                var tag = System.IO.Path.GetFileName(dir);
                Person p = new Person();
                p.PersonName = tag;

                var faces = new ObservableCollection<Face>();
                p.Faces = faces;

                // Call create person REST API, the new create person id will be returned
                System.Diagnostics.Debug.WriteLine("Request: Creating person \"{0}\"", p.PersonName);
                p.PersonId = (await faceServiceClient.CreatePersonInLargePersonGroupAsync(this.GroupId, p.PersonName)).PersonId.ToString();
                System.Diagnostics.Debug.WriteLine("Response: Success. Person \"{0}\" (PersonID:{1}) created", p.PersonName, p.PersonId);

                string img;
                // Enumerate images under the person folder, call detection
                var imageList =
                new ConcurrentBag<string>(
                    Directory.EnumerateFiles(dir, "*.*", SearchOption.AllDirectories)
                        .Where(s => s.ToLower().EndsWith(".jpg") || s.ToLower().EndsWith(".png") || s.ToLower().EndsWith(".bmp") || s.ToLower().EndsWith(".gif")));
                while (imageList.TryTake(out img))
                {
                    tasks.Add(Task.Factory.StartNew(
                        async (obj) =>
                        {
                            var imgPath = obj as string;

                            using (var fStream = File.OpenRead(imgPath))
                            {
                                try
                                {
                                    // Update person faces on server side
                                    var persistFace = await faceServiceClient.AddPersonFaceInLargePersonGroupAsync(this.GroupId, Guid.Parse(p.PersonId), fStream, imgPath);
                                    return new Tuple<string, ClientContract.AddPersistedFaceResult>(imgPath, persistFace);
                                }
                                catch (FaceAPIException ex)
                                {
                                    // if operation conflict, retry.
                                    if (ex.ErrorCode.Equals("ConcurrentOperationConflict"))
                                    {
                                        imageList.Add(imgPath);
                                        return null;
                                    }
                                    // if operation cause rate limit exceed, retry.
                                    else if (ex.ErrorCode.Equals("RateLimitExceeded"))
                                    {
                                        imageList.Add(imgPath);
                                        return null;
                                    }
                                    else if (ex.ErrorMessage.Contains("more than 1 face in the image."))
                                    {
                                        Interlocked.Increment(ref invalidImageCount);
                                    }
                                    // Here we simply ignore all detection failure in this sample
                                    // You may handle these exceptions by check the Error.Error.Code and Error.Message property for ClientException object
                                    return new Tuple<string, ClientContract.AddPersistedFaceResult>(imgPath, null);
                                }
                            }
                        },
                        img).Unwrap().ContinueWith((detectTask) =>
                        {
                            // Update detected faces for rendering
                            var detectionResult = detectTask?.Result;
                            if (detectionResult == null || detectionResult.Item2 == null)
                            {
                                return;
                            }
                           
                            //    Dispatcher.Invoke(
                            //        new Action<ObservableCollection<Face>, string, ClientContract.AddPersistedFaceResult>(UIHelper.UpdateFace),
                            //        faces,
                            //        detectionResult.Item1,
                            //        detectionResult.Item2);
                            }));
                            //    if (processCount >= SuggestionCount && !forceContinue)
                            //    {
                            //        var continueProcess = System.Windows.Forms.MessageBox.Show("The images loaded have reached the recommended count, may take long time if proceed. Would you like to continue to load images?", "Warning", System.Windows.Forms.MessageBoxButtons.YesNo);
                            //        if (continueProcess == System.Windows.Forms.DialogResult.Yes)
                            //        {
                            //            forceContinue = true;
                            //        }
                            //        else
                            //        {
                            //            break;
                            //        }
                            //    }

                            //    if (tasks.Count >= _maxConcurrentProcesses || imageList.IsEmpty)
                            //    {
                            //        await Task.WhenAll(tasks);
                            //        tasks.Clear();
                            //    }
                            //}

                            

                        
                }

                Persons.Add(p);
            }
        }

                // POST api/values
                public void Post([FromBody]string value)
                {
                }

                // PUT api/values/5
                public void Put(int id, [FromBody]string value)
                {
                }

                // DELETE api/values/5
                public void Delete(int id)
                {
                }

        public string GroupId
        {
            get
            {
                return sampleGroupId;
            }

            set
            {
                sampleGroupId = value;
            }
        }

        public ObservableCollection<Person> Persons
        {
            get
            {
                return _persons;
            }
        }

        public ObservableCollection<Face> TargetFaces
        {
            get
            {
                return _faces;
            }
        }

        /// <summary>
        /// Gets or sets user picked image file
        /// </summary>
        public ImageSource SelectedFile
        {
            get
            {
                return _selectedFile;
            }

            set
            {
                _selectedFile = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("SelectedFile"));
                }
            }
        }




        public class Person : INotifyPropertyChanged
        {
            #region Fields

            /// <summary>
            /// Person's faces from database
            /// </summary>
            private ObservableCollection<Face> _faces = new ObservableCollection<Face>();

            /// <summary>
            /// Person's id
            /// </summary>
            private string _personId;

            /// <summary>
            /// Person's name
            /// </summary>
            private string _personName;

            #endregion Fields

            #region Events

            /// <summary>
            /// Implement INotifyPropertyChanged interface
            /// </summary>
            public event PropertyChangedEventHandler PropertyChanged;

            #endregion Events

            #region Properties

            /// <summary>
            /// Gets or sets person's faces from database
            /// </summary>
            public ObservableCollection<Face> Faces
            {
                get
                {
                    return _faces;
                }

                set
                {
                    _faces = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("Faces"));
                    }
                }
            }

            /// <summary>
            /// Gets or sets person's id
            /// </summary>
            public string PersonId
            {
                get
                {
                    return _personId;
                }

                set
                {
                    _personId = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("PersonId"));
                    }
                }
            }

            /// <summary>
            /// Gets or sets person's name
            /// </summary>
            public string PersonName
            {
                get
                {
                    return _personName;
                }

                set
                {
                    _personName = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("PersonName"));
                    }
                }
            }

            #endregion Properties
        }
    }
}

