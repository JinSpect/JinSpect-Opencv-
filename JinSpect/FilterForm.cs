using JinSpect.Property;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace JinSpect
{
    public enum PropertyType
    {
        None,
        Grayscale,
        HSVscale,
        Flip,
        Pyramid,
        Resize,
        
    }

    public partial class FilterForm : DockContent
    {
        Dictionary<string, TabPage> _allTabs = new Dictionary<string, TabPage>();
        public FilterForm()
        {
            InitializeComponent();
            LoadOptionControl(PropertyType.Flip);
            LoadOptionControl(PropertyType.Resize);
            LoadOptionControl(PropertyType.Pyramid);
            
        }
        private void LoadOptionControl(PropertyType propType)
        {
            string tabName = propType.ToString();

            
            foreach (TabPage tabPage in tabPropControl.TabPages)
            {
                if (tabPage.Text == tabName)
                    return;
            }

            
            if (_allTabs.TryGetValue(tabName, out TabPage page))
            {
                tabPropControl.TabPages.Add(page);
                return;
            }
            
            UserControl _inspProp = CreateUserControl(propType);
            if (_inspProp == null)
                return;


            TabPage newTab = new TabPage(tabName)
            {
                Name = tabName,
                Dock = DockStyle.Fill
            };
            _inspProp.Dock = DockStyle.Fill;
            newTab.Controls.Add(_inspProp);
            tabPropControl.TabPages.Add(newTab);
            tabPropControl.SelectedTab = newTab; 

            _allTabs[tabName] = newTab;
        }
        public TabPage GetTabPage(string tabName)
        {
            foreach (TabPage tab in tabPropControl.TabPages)
            {
                if (tab.Text == tabName)
                    return tab;
            }
            return null;
        }
        private UserControl CreateUserControl(PropertyType propType)
        {
            UserControl curProp = null;

            switch (propType)
            {
                case PropertyType.Flip:
                    curProp = new FlipProp(); 
                    break;

                case PropertyType.Resize: 
                    curProp = new ResizeProp();
                    break;


                case PropertyType.Pyramid:
                    curProp = new PyramidProp();
                    break;


                default:
                    MessageBox.Show("유효하지 않은 옵션입니다.");
                    return null;
            }

            return curProp;
        }
        public void SelectTab(string tabName)
        {
            foreach (TabPage tab in tabPropControl.TabPages)
            {
                if (tab.Text == tabName || tab.Name == tabName)
                {
                    tabPropControl.SelectedTab = tab;
                    return;
                }
            }

           
            if (Enum.TryParse(tabName, out PropertyType type))
            {
                LoadOptionControl(type);
                SelectTab(tabName); 
            }
            else
            {
                MessageBox.Show($"'{tabName}' 탭을 찾을 수 없습니다.");
            }
        }



    }

    //internal class FlipProp : UserControl
    //{

    //}
}
