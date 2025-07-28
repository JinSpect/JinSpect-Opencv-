using SaigeVision.Net.V2;
using SaigeVision.Net.V2.Classification;
using SaigeVision.Net.V2.Detection;
using SaigeVision.Net.V2.IAD;
using SaigeVision.Net.V2.Segmentation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;


namespace JinSpect.inspect
{

    public class SaigeAI : IDisposable //Disposable 인터페이스 구현
    {

        //IADEngine _iADEngine = null;
        //IADResult _iADresult = null;
        //Bitmap _inspImage = null;

        public enum EngineType { SEG, DET, IAD }
        private Dictionary<string, IADResult> _IADResults;
        private Dictionary<string, DetectionResult> _DETResults;
        private Dictionary<string, SegmentationResult> _SEGResults;
        private EngineType _engineType;

        IADEngine _iADEngine = null;
        IADResult _iADresult = null;

        Bitmap _inspImage = null;

        DetectionEngine _dETEngine = null;
        DetectionResult _dETresult = null;

        SegmentationEngine _sEGEngine = null;
        SegmentationResult _SEGResult = null;

        public SaigeAI()
        {
            _IADResults = new Dictionary<string, IADResult>();
            _DETResults = new Dictionary<string, DetectionResult>();
            _SEGResults = new Dictionary<string, SegmentationResult>();
        }

        public void LoadEngine(string modelPath, EngineType type)
        {
            _engineType = type;

            //    if (this._iADEngine != null)
            //        this._iADEngine.Dispose();

            //    _iADEngine = new IADEngine(modelPath, 0);

            //    IADOption option = _iADEngine.GetInferenceOption();

            //    option.CalcScoremap = false;
            //    option.CalcHeatmap = false;
            //    option.CalcMask = false;
            //    option.CalcObject = true;
            //    option.CalcObjectAreaAndApplyThreshold = true;
            //    option.CalcObjectScoreAndApplyThreshold = true;
            //    option.CalcTime = true;

            //    _iADEngine.SetInferenceOption(option);
            //}
           
            if (_sEGEngine != null)
                _sEGEngine.Dispose();
            _sEGEngine = null;

            if (_dETEngine != null)
                _dETEngine.Dispose();
            _dETEngine = null;

            if (_iADEngine != null)
                _iADEngine.Dispose();
            _iADEngine = null;

            switch (type)
            {

                case EngineType.SEG:
                    _sEGEngine = new SegmentationEngine(modelPath, 0);
                    var segOption = _sEGEngine.GetInferenceOption();
                    segOption.CalcTime = true;
                    segOption.CalcObject = true;
                    segOption.CalcScoremap = false;
                    segOption.CalcMask = false;
                    segOption.CalcObjectAreaAndApplyThreshold = true;
                    segOption.CalcObjectScoreAndApplyThreshold = true;
                    _sEGEngine.SetInferenceOption(segOption);
                    break;

                case EngineType.DET:
                    _dETEngine = new DetectionEngine(modelPath, 0);
                    var detOpt = _dETEngine.GetInferenceOption();
                    detOpt.CalcTime = true;
                    _dETEngine.SetInferenceOption(detOpt);
                    break;

                    case EngineType.IAD:
                    _iADEngine = new IADEngine(modelPath, 0);
                    var iadOpt = _iADEngine.GetInferenceOption();
                    iadOpt.CalcObject = true;
                    iadOpt.CalcObjectAreaAndApplyThreshold = true;
                    iadOpt.CalcObjectScoreAndApplyThreshold = true;
                    iadOpt.CalcTime = true;
                    _iADEngine.SetInferenceOption(iadOpt);
                    break;

                

            }
        }

        //public bool InspIAD(Bitmap bmpImage)
        //{
        //    if(_iADEngine == null)
        //    {
        //        MessageBox.Show("엔진이 초기화되지 않았습니다. LoadEngine 메서드를 호출하여 엔진을 초기화하세요.");
        //        return false;
        //    }

        //    _inspImage = bmpImage;

        //    SrImage srImage = new SrImage(bmpImage);

        //    _iADresult = _iADEngine.Inspection(srImage);
        //    return true;
        //}

        private void DrawIADResult(IADResult result, Bitmap bmp)
        {
            Graphics g = Graphics.FromImage(bmp);
            int step = 10;

            if (result.SegmentedObjects is null)
                return;

            foreach (var prediction in result.SegmentedObjects)
            {
                SolidBrush brush = new SolidBrush(Color.FromArgb(127, prediction.ClassInfo.Color));
                using (GraphicsPath gp = new GraphicsPath())
                {
                    if (prediction.Contour.Value.Count < 3) continue;
                    gp.AddPolygon(prediction.Contour.Value.ToArray());
                    foreach (var innerValue in prediction.Contour.InnerValue)
                    {
                        gp.AddPolygon(innerValue.ToArray());
                    }
                    g.FillPath(brush, gp);
                }
                step += 50;
            }
        }

        private void DrawSEGResult(SegmentationResult result, Bitmap bmp)
        {
            Graphics g = Graphics.FromImage(bmp);
            int step = 10;

            // outline contour
            foreach (var prediction in _SEGResult.SegmentedObjects)
            {
                SolidBrush brush = new SolidBrush(Color.FromArgb(127, prediction.ClassInfo.Color));
                using (GraphicsPath gp = new GraphicsPath())
                {
                    if (prediction.Contour.Value.Count < 4) continue;
                    gp.AddPolygon(prediction.Contour.Value.ToArray());
                    foreach (var innerValue in prediction.Contour.InnerValue)
                    {
                        gp.AddPolygon(innerValue.ToArray());
                    }
                    g.FillPath(brush, gp);
                }
                step += 50;
            }
        }

        private void DrawDetectionResult(DetectionResult result, Bitmap bmp)
        {
            Graphics g = Graphics.FromImage(bmp);
            int step = 10;

            // outline contour
            foreach (var prediction in result.DetectedObjects)
            {
                SolidBrush brush = new SolidBrush(Color.FromArgb(127, prediction.ClassInfo.Color));
                //g.DrawString(prediction.ClassInfo.Name + " : " + prediction.Area, new Font(FontFamily.GenericSansSerif, 50), brush, 10, step);
                using (GraphicsPath gp = new GraphicsPath())
                {
                    float x = (float)prediction.BoundingBox.X;
                    float y = (float)prediction.BoundingBox.Y;
                    float width = (float)prediction.BoundingBox.Width;
                    float height = (float)prediction.BoundingBox.Height;
                    gp.AddRectangle(new RectangleF(x, y, width, height));
                    g.DrawPath(new Pen(brush, 10), gp);
                }
                step += 50;
            }
        }

        public bool RunInspection(Bitmap bmpImage)
        {
            if (bmpImage == null)
                return false;

            _inspImage = bmpImage;
            SrImage srImage = new SrImage(bmpImage);
            Stopwatch sw = Stopwatch.StartNew();

            bool success = false;

            switch (_engineType)
            {
                case EngineType.IAD:
                    if (_iADEngine == null)
                    {
                        Console.WriteLine("IAD 엔진이 초기화되지 않았습니다.");
                        return false;
                    }
                    _iADresult = _iADEngine.Inspection(srImage);
                    success = _iADresult != null;
                    break;

                case EngineType.SEG:
                    if (_sEGEngine == null)
                    {
                        Console.WriteLine("SEG 엔진이 초기화되지 않았습니다.");
                        return false;
                    }
                    _SEGResult = _sEGEngine.Inspection(srImage);
                    success = _SEGResult != null;
                    break;

                case EngineType.DET:
                    if (_dETEngine == null)
                    {
                        Console.WriteLine("Detection 엔진이 초기화되지 않았습니다.");
                        return false;
                    }
                    _dETresult = _dETEngine.Inspection(srImage);
                    success = _dETresult != null;
                    break;

                default:
                    Console.WriteLine("지원하지 않는 엔진 타입입니다.");
                    return false;
            }

            sw.Stop();
            return success;
        }

        public Bitmap GetResultImage()
        {
            //if (_iADresult == null || _inspImage is null)
            //    return null;

            //Bitmap resultImage = _inspImage.Clone(new Rectangle(0, 0, _inspImage.Width, _inspImage.Height), System.Drawing.Imaging.PixelFormat.Format24bppRgb);

            //DrawIADResult(_iADresult, resultImage);

            //return resultImage;
            if (_inspImage == null)
                return null;
            Bitmap resultImage = _inspImage.Clone(
        new Rectangle(0, 0, _inspImage.Width, _inspImage.Height), System.Drawing.Imaging.PixelFormat.Format24bppRgb);

            switch (_engineType)
            {
                case EngineType.IAD:
                    if (_iADresult != null)
                        DrawIADResult(_iADresult, resultImage);
                    break;

                case EngineType.SEG:
                    if (_SEGResult != null)
                        DrawSEGResult(_SEGResult, resultImage);
                    break;

                case EngineType.DET:
                    if (_dETresult != null)
                        DrawDetectionResult(_dETresult, resultImage);
                    break;
            }
            return resultImage;
        }


        #region Disposable

        private bool disposed = false;


        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    if (_iADEngine != null)
                        _iADEngine.Dispose();
                }

                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }

        #endregion

    }

}

//internal class SaigeAI

