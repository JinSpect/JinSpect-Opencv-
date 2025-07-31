using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JinSpect.Processor
{
    internal class ImageFilterProcessor
    {
        public static Mat Apply(Mat src, PropertyType filter, dynamic options = null)
        {
            Mat dst = new Mat();

            switch (filter)
            {
                case PropertyType.Grayscale:
                    if (src.Channels() == 1)
                    {
                        dst = src.Clone(); // 이미 흑백이면 그대로 복사
                    }
                    else
                    {
                        Cv2.CvtColor(src, dst, ColorConversionCodes.BGR2GRAY);
                    }
                    break;

                case PropertyType.HSVscale:
                    if (src.Channels() == 1)
                    {
                        MessageBox.Show("흑백 이미지에는 HSV 변환을 적용할 수 없습니다.");
                        dst = src.Clone();
                    }
                    else
                    {
                        Cv2.CvtColor(src, dst, ColorConversionCodes.BGR2HSV);
                    }
                    break;
                case PropertyType.Flip:
                    FlipMode mode = (FlipMode)options.FlipMode;
                    Cv2.Flip(src, dst, mode);
                    break;
                case PropertyType.Pyramid:
                    string direction = options?.Direction ?? "Down";
                    if (direction == "Up")
                        Cv2.PyrUp(src, dst);
                    else
                        Cv2.PyrDown(src, dst);
                    break;
                case PropertyType.Resize:
                    double fx = options.Fx / 100.0;
                    double fy = options.Fy / 100.0;
                    Cv2.Resize(src, dst, new Size(), fx, fy);
                    break;
                
                default:
                    dst = src.Clone();
                    break;
            }

            return dst;
        }
    }
}
