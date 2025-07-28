using JinSpect.Core;
using JinSpect.inspect;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static JinSpect.inspect.SaigeAI;

namespace JinSpect.Property
{
    public partial class AIModuleProp : UserControl
    {
        SaigeAI _saigeAI;
        string _modelPath = string.Empty;

        public AIModuleProp()
        {
            InitializeComponent();
            cbEngineType.DataSource = Enum.GetValues(typeof(EngineType));
        }

        private void btnSelAIModel_Click(object sender, EventArgs e)
        {
            int selType = cbEngineType.SelectedIndex;
            string ext = "AI Filse|*.*;";

            switch(selType)
            {
                case 0:
                    ext = "AI Filse|*.saigeseg;";
                    break;
                case 1:
                    ext = "AI Filse|*.saigedet;";
                    break;
                case 2:
                    ext = "AI Filse|*.saigeiad;";
                    break;

            }


            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "AI 모델 파일 선택";
                openFileDialog.Filter = ext;
                openFileDialog.Multiselect = false;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _modelPath = openFileDialog.FileName;
                    txtAIModelPath.Text = _modelPath;

                }
            }
        }

        private void btnLoadModel_Click(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(_modelPath))
            //{
            //    MessageBox.Show("모델 파일을 선택해주세요.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            //if (_saigeAI == null)
            //{
            //    _saigeAI = Global.Inst.InspStage.AIModul;
            //}

            //_saigeAI.LoadEngine(_modelPath);
            //MessageBox.Show("모델이 성공적으로 로드되었습니다", "정보", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (string.IsNullOrEmpty(_modelPath))
            {
                MessageBox.Show("모델 파일을 선택해주세요.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_saigeAI == null)
            {
                _saigeAI = Global.Inst.InspStage.AIModule;
            }
            if (cbEngineType.SelectedItem is EngineType selectedType)
            {
                try
                {
                    _saigeAI.LoadEngine(_modelPath, selectedType);
                    MessageBox.Show("모델이 성공적으로 로드되었습니다.", "정보", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"모델 로드 실패: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("엔진 타입을 선택해주세요.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnInspAI_Click(object sender, EventArgs e)
        {
            if (_saigeAI == null)
            {
                MessageBox.Show("AI 모듈이 초기화되지 않았습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Bitmap bitmap = Global.Inst.InspStage.GetCurrentImage();
            _saigeAI.RunInspection(bitmap);

            Bitmap resultImage = _saigeAI.GetResultImage();

            Global.Inst.InspStage.UpdateDisplay(resultImage);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtAIModelPath_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
