using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace JinSpect
{
    public partial class CameraForm : DockContent
    {
        private Stack<Mat> _imgHistory = new Stack<Mat>();
        private Stack<Mat> _redoImg = new Stack<Mat>();
        private bool _useAccumulativeFilter = false;
        private Mat _originalImage;
        private bool _isFirstApply = true;


        public CameraForm()
        {
            InitializeComponent();
        }

        public Bitmap GetCurrentBitmap()
        {
            return imageViewer.GetCurBitmap();
        }
        public void LoadImage(string filPath)
        {
            if (File.Exists(filPath) == false)
                return;

            Image bitmap = Image.FromFile(filPath);
            var mat = OpenCvSharp.Extensions.BitmapConverter.ToMat((Bitmap)bitmap);

            _originalImage = mat.Clone();
            _imgHistory.Clear();
            _redoImg.Clear();
            _isFirstApply = true;

            imageViewer.LoadBitmap((Bitmap)bitmap);
        }

        public void LoadImage(Bitmap bitmap)
        {
            var mat = BitmapConverter.ToMat(bitmap);

            _originalImage = mat.Clone();
            _imgHistory.Clear();
            _redoImg.Clear();
            _isFirstApply = true;

            imageViewer.LoadBitmap(bitmap);
        }

        private void CameraForm_Resize(object sender, EventArgs e)
        {
            int margin = 0;
            imageViewer.Width = this.Width - margin * 2;
            imageViewer.Height = this.Height - margin * 2;

            imageViewer.Location = new System.Drawing.Point(margin, margin);
        }
        public void SerFilterMode(bool enableAccumulative)
        {
            _useAccumulativeFilter = enableAccumulative;
            _isFirstApply = true;
        }
        public void ApplyFilter(PropertyType filterType, dynamic options = null)
        {
            if (_originalImage == null)
            {
                MessageBox.Show("원본 이미지가 없습니다.");
                return;
            }

            Mat src;
            if (filterType == PropertyType.Pyramid)
            {
                src = _useAccumulativeFilter
                    ? BitmapConverter.ToMat(GetCurrentBitmap())
                    : _originalImage.Clone();
            }
            else
            {
                src = _useAccumulativeFilter
                    ? BitmapConverter.ToMat(GetCurrentBitmap())
                    : _originalImage.Clone();
            }
            _imgHistory.Push(src.Clone());
            _redoImg.Clear();

            Mat result = Processor.ImageFilterProcessor.Apply(src, filterType, options);
            imageViewer.LoadBitmap(result.ToBitmap());
        }

        public void Undo()
        {
            if (_imgHistory.Count > 0)
            {
                var current = BitmapConverter.ToMat(GetCurrentBitmap());
                _redoImg.Push(current.Clone());

                var prev = _imgHistory.Pop();
                imageViewer.LoadBitmap(prev.ToBitmap());
            }
            else
            {
                MessageBox.Show("되돌릴 수 있는 이전 이미지가 없습니다.");
            }
        }

        public void Redo()
        {
            if (_redoImg.Count > 0)
            {
                var current = BitmapConverter.ToMat(GetCurrentBitmap());
                _imgHistory.Push(current.Clone());

                var redo = _redoImg.Pop();
                imageViewer.LoadBitmap(redo.ToBitmap());
            }
            else
            {
                MessageBox.Show("다시 실행할 수 있는 단계가 없습니다.");
            }
        }
        public void RestoreOriginal()
        {
            if (_originalImage != null)
            {
                imageViewer.LoadBitmap(_originalImage.ToBitmap());
                _isFirstApply = true;
                _imgHistory.Clear();
                _redoImg.Clear();
            }
            else
            {
                MessageBox.Show("원본 이미지가 없습니다.");
            }
        }
        public void PreviewFilter(PropertyType filterType, dynamic options = null)
        {
            if (_originalImage == null) return;

            Mat previewBase = _useAccumulativeFilter
                ? BitmapConverter.ToMat(GetCurrentBitmap())
                : _originalImage.Clone();

            Mat previewResult = Processor.ImageFilterProcessor.Apply(previewBase, filterType, options);

            imageViewer.LoadBitmap(previewResult.ToBitmap());
        }
    }
}

//public void UpdateDisplay(Bitmap bitmap = null)
//        {
//            if (imageViewer != null)
//                imageViewer.LoadBitmap(bitmap);
//        }

//        public Bitmap GetDisplayImage()
//        {
//            Bitmap curImage = null;

//            if (imageViewer != null)
//                curImage = imageViewer.GetCurBitmap();

//            return curImage;
//        }
//    }
//}
