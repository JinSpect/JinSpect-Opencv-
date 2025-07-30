using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JinSpect.Property;
using WeifenLuo.WinFormsUI.Docking;


namespace JinSpect
{
    public partial class PropertiesForm : DockContent
    {
        private PropertyType _selectedFilter = PropertyType.None;

        public PropertiesForm()
        {
            InitializeComponent();
            cbList.SelectedIndexChanged += cbList_SelectedIndexChanged;
            checkFilter.CheckedChanged += checkFilter_CheckedChanged;
        }
        private void OnRotationPreview(object sender, EventArgs e)
        {
            var cameraForm = MainForm.GetDockForm<CameraForm>();
            if (cameraForm == null) return;

            //if (sender is RotateProp rotateProp)
            //{
            //    int angle = rotateProp.Angle;
            //    cameraForm.PreviewFilter(PropertyType.Rotation, new { Angle = angle });
            //}
        }
        private void cbList_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbList.SelectedIndex)
            {
                case 0: _selectedFilter = PropertyType.Grayscale; break;
                case 1: _selectedFilter = PropertyType.HSVscale; break;
                case 2: _selectedFilter = PropertyType.Flip; break;
                case 3: _selectedFilter = PropertyType.Pyramid; break;
                case 4: _selectedFilter = PropertyType.Resize; break;
                default: _selectedFilter = PropertyType.None; break;
            }
            if (_selectedFilter == PropertyType.Grayscale || _selectedFilter == PropertyType.HSVscale)
                return;

            var filterForm = MainForm.SharedFilterForm;
            if (filterForm != null)
            {
                filterForm.SelectTab(_selectedFilter.ToString());
                //if (_selectedFilter == PropertyType.Rotation)
                //{
                //    ////var tab = filterForm.GetTabPage("Rotation");
                //    ////if (tab != null && tab.Controls[0] is RotateProp rotateProp)
                //    //{

                //    //    rotateProp.Preview -= OnRotationPreview;
                //    //    rotateProp.Preview += OnRotationPreview;
                //    //}
                //}
            }
            else
            {
                MessageBox.Show("FilterForm을 찾을 수 없습니다.");
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            var cameraForm = MainForm.GetDockForm<CameraForm>();
            if (cameraForm == null)
            {
                MessageBox.Show("카메라 창을 찾을 수 없습니다.");
                return;
            }

            dynamic options = null;

            switch (_selectedFilter)
            {
                case PropertyType.Flip:
                    {
                        var filterForm = MainForm.SharedFilterForm;
                        if (filterForm != null)
                        {
                            var tab = filterForm.GetTabPage("Flip");
                            if (tab != null && tab.Controls.Count > 0 && tab.Controls[0] is FlipProp flipProp)
                            {
                                var selected = flipProp.SelectedFlipMode;
                                if (selected == null)
                                {
                                    MessageBox.Show("반전 모드를 선택하세요.");
                                    return;
                                }

                                options = new { FlipMode = selected.Value };
                            }
                            else
                            {
                                MessageBox.Show("Flip 설정을 찾을 수 없습니다.");
                                return;
                            }
                        }
                        break;
                    }

                case PropertyType.Pyramid:
                    {
                        var filterForm = MainForm.SharedFilterForm;
                        if (filterForm != null)
                        {
                            var tab = filterForm.GetTabPage("Pyramid");
                            if (tab != null && tab.Controls.Count > 0 && tab.Controls[0] is PyramidProp pyramidProp)
                            {
                                string direction = pyramidProp.SelectedDirection;
                                options = new { Direction = direction };
                            }
                            else
                            {
                                MessageBox.Show("Pyramid 설정을 찾을 수 없습니다.");
                                return;
                            }
                        }
                        break;
                    }

                case PropertyType.Resize:
                    {
                        var filterForm = MainForm.SharedFilterForm;
                        var tab = filterForm?.GetTabPage("Resize");
                        if (tab != null && tab.Controls[0] is ResizeProp resizeProp)
                        {
                            double fx = (double)resizeProp.NumericUpDownX.Value;
                            double fy = (double)resizeProp.NumericUpDownY.Value;

                            if (fx <= 0 || fx > 1000 || fy <= 0 || fy > 1000)
                            {
                                MessageBox.Show("0보다 크고 1000 이하의 값을 입력하세요.");
                                return;
                            }

                            options = new { Fx = fx, Fy = fy };
                        }
                        else
                        {
                            MessageBox.Show("Resize 설정을 찾을 수 없습니다.");
                            return;
                        }
                        break;
                    }
                
            }

            cameraForm.ApplyFilter(_selectedFilter, options);
        }


        private void btnUndo_Click_1(object sender, EventArgs e)
        {
            var cameraForm = MainForm.GetDockForm<CameraForm>();
            cameraForm?.Undo();
        }

        private void btnRedo_Click_1(object sender, EventArgs e)
        {
            var cameraForm = MainForm.GetDockForm<CameraForm>();
            cameraForm?.Redo();
        }

        private void btnSrc_Click_1(object sender, EventArgs e)
        {
            var cameraForm = MainForm.GetDockForm<CameraForm>();
            cameraForm?.RestoreOriginal();
        }

        private void checkFilter_CheckedChanged(object sender, EventArgs e)
        {
            var cameraForm = MainForm.GetDockForm<CameraForm>();
            if (cameraForm != null)
            {
                cameraForm.SerFilterMode(checkFilter.Checked);
            }
        }
    }
}

