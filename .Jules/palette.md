# Palette Journal

## 2024-05-21 - Skip Link for Fixed Headers
**Learning:** In legacy Bootstrap 3 apps with `navbar-fixed-top`, standard "sr-only" classes might hide focused elements behind the navbar.
**Action:** Use absolute positioning with high z-index (e.g., `z-index: 10000`) and explicit `top` offsets to ensure "Skip to content" links appear *over* the fixed header when focused.
