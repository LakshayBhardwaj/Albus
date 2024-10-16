﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Windows.Media;

namespace WebRole1.Controllers
{
    public class Face : INotifyPropertyChanged
    {
        #region Fields

        /// <summary>
        /// Face age text string
        /// </summary>
        private string _age;

        /// <summary>
        /// Face gender text string
        /// </summary>
        private string _gender;

        /// <summary>
        /// confidence value of this face to a target face
        /// </summary>
        private double _confidence;

        /// <summary>
        /// Person name
        /// </summary>
        private string _personName;

        /// <summary>
        /// Face height in pixel
        /// </summary>
        private int _height;

        /// <summary>
        /// Face position X relative to image left-top in pixel
        /// </summary>
        private int _left;

        /// <summary>
        /// Face position Y relative to image left-top in pixel
        /// </summary>
        private int _top;

        /// <summary>
        /// Face width in pixel
        /// </summary>
        private int _width;

        /// <summary>
        /// Indicates the headPose
        /// </summary>
        private string _headPose;

        /// <summary>
        /// Facial hair display string
        /// </summary>
        private string _facialHair;

        /// <summary>
        /// Indicates the glasses type
        /// </summary>
        private string _glasses;

        /// <summary>
        /// Indicates the emotion
        /// </summary>
        private string _emotion;

        /// <summary>
        /// Indicates the hair
        /// </summary>
        private string _hair;

        /// <summary>
        /// Indicates the makeup
        /// </summary>
        private string _makeup;

        /// <summary>
        /// Indicates the eye occlusion
        /// </summary>
        private string _eyeOcclusion;

        /// <summary>
        /// Indicates the forehead occlusion
        /// </summary>
        private string _foreheadOcclusion;

        /// <summary>
        /// Indicates the mouth occlusion
        /// </summary>
        private string _mouthOcclusion;

        /// <summary>
        /// Indicates the accessories
        /// </summary>
        private string _accessories;

        /// <summary>
        /// Indicates the blur
        /// </summary>
        private string _blur;

        /// <summary>
        /// Indicates the exposure
        /// </summary>
        private string _exposure;

        /// <summary>
        /// Indicates the noise
        /// </summary>
        private string _noise;

        #endregion Fields

        #region Events

        /// <summary>
        /// Implement INotifyPropertyChanged interface
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion Events

        #region Properties

        /// <summary>
        /// Gets or sets age text string
        /// </summary>
        public string Age
        {
            get
            {
                return _age;
            }

            set
            {
                _age = value;
                OnPropertyChanged<string>();
            }
        }

        /// <summary>
        /// Gets or sets gender text string 
        /// </summary>
        public string Gender
        {
            get
            {
                return _gender;
            }

            set
            {
                _gender = value;
                OnPropertyChanged<string>();
            }
        }

        /// <summary>
        /// Gets or sets confidence value
        /// </summary>
        public double Confidence
        {
            get
            {
                return _confidence;
            }

            set
            {
                _confidence = value;
                OnPropertyChanged<double>();
            }
        }

        /// <summary>
        /// Gets face rectangle on image
        /// </summary>
        public System.Windows.Int32Rect UIRect
        {
            get
            {
                return new System.Windows.Int32Rect(Left, Top, Width, Height);
            }
        }

        /// <summary>
        /// Gets or sets image path
        /// </summary>
        public ImageSource ImageFile
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets face id
        /// </summary>
        public string FaceId
        {
            get;
            set;
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
                OnPropertyChanged<string>();
            }
        }

        /// <summary>
        /// Gets or sets face height
        /// </summary>
        public int Height
        {
            get
            {
                return _height;
            }

            set
            {
                _height = value;
                OnPropertyChanged<int>();
            }
        }

        /// <summary>
        /// Gets or sets face position X
        /// </summary>
        public int Left
        {
            get
            {
                return _left;
            }

            set
            {
                _left = value;
                OnPropertyChanged<int>();
            }
        }

        /// <summary>
        /// Gets or sets face position Y
        /// </summary>
        public int Top
        {
            get
            {
                return _top;
            }

            set
            {
                _top = value;
                OnPropertyChanged<int>();
            }
        }

        /// <summary>
        /// Gets or sets face width
        /// </summary>
        public int Width
        {
            get
            {
                return _width;
            }

            set
            {
                _width = value;
                OnPropertyChanged<int>();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating the head pose value.
        /// </summary>
        public string HeadPose
        {
            get { return _headPose; }
            set
            {
                _headPose = value;
                OnPropertyChanged<string>();
            }
        }

        /// <summary>
        /// Gets or sets facial hair display string
        /// </summary>
        public string FacialHair
        {
            get
            {
                return _facialHair;
            }

            set
            {
                _facialHair = value;
                OnPropertyChanged<string>();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating the glasses type 
        /// </summary>
        public string Glasses
        {
            get
            {
                return _glasses;
            }

            set
            {
                _glasses = value;
                OnPropertyChanged<string>();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating the emotion type
        /// </summary>
        public string Emotion
        {
            get { return _emotion; }
            set
            {
                _emotion = value;
                OnPropertyChanged<string>();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating the hair type
        /// </summary>
        public string Hair
        {
            get { return _hair; }
            set
            {
                _hair = value;
                OnPropertyChanged<string>();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating the makeup type
        /// </summary>
        public string Makeup
        {
            get { return _makeup; }
            set
            {
                _makeup = value;
                OnPropertyChanged<string>();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating the occlusion type of eye
        /// </summary>
        public string EyeOcclusion
        {
            get { return _eyeOcclusion; }
            set
            {
                _eyeOcclusion = value;
                OnPropertyChanged<string>();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating the occlusion type of forehead
        /// </summary>
        public string ForeheadOcclusion
        {
            get { return _foreheadOcclusion; }
            set
            {
                _foreheadOcclusion = value;
                OnPropertyChanged<string>();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating the occlusion type of mouth
        /// </summary>
        public string MouthOcclusion
        {
            get { return _mouthOcclusion; }
            set
            {
                _mouthOcclusion = value;
                OnPropertyChanged<string>();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating the accessories type
        /// </summary>
        public string Accessories
        {
            get { return _accessories; }
            set
            {
                _accessories = value;
                OnPropertyChanged<string>();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating the blur type
        /// </summary>
        public string Blur
        {
            get { return _blur; }
            set
            {
                _blur = value;
                OnPropertyChanged<string>();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating the exposure type
        /// </summary>
        public string Exposure
        {
            get { return _exposure; }
            set
            {
                _exposure = value;
                OnPropertyChanged<string>();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating the noise type
        /// </summary>
        public string Noise
        {
            get { return _noise; }
            set
            {
                _noise = value;
                OnPropertyChanged<string>();
            }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// NotifyProperty Helper functions
        /// </summary>
        /// <typeparam name="T">property type</typeparam>
        /// <param name="caller">property change caller</param>
        private void OnPropertyChanged<T>([CallerMemberName]string caller = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(caller));
            }
        }

        #endregion Methods
    }
}