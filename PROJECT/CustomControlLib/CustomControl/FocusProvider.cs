using System.ComponentModel;
using System.Collections;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;

namespace CustomControlLib
{

    [ProvideProperty("EnterPressed", typeof(Control))]
    [ToolboxItemFilter("System.Windows.Forms")]
    public partial class FocusProvider : Component,IExtenderProvider
    {
        private Hashtable properties;

        public FocusProvider()
        {
            properties = new Hashtable();
            InitializeComponent();
            
        }

        public FocusProvider(IContainer container):this()
        {
            container.Add(this);
            InitializeComponent();
        }

        #region Method
        [Category("Focus")]
        public Control GetEnterPressed( Control control )
        {
            return EnsurePropertiesExists(control).ControlInfo;
        }

        public void SetEnterPressed(Control control,Control controlProvider)
        {
           EnsurePropertiesExists(control).ControlInfo = controlProvider;
           control.PreviewKeyDown += new PreviewKeyDownEventHandler(control_PreviewKeyDown);
        }

        void control_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            Control nextFocusControl = GetEnterPressed(sender as Control);

            if (nextFocusControl != null && nextFocusControl.CanFocus == true)
                if (e.KeyData == Keys.Enter)
                {
                    nextFocusControl.Focus();

                }
        }


        private Properties EnsurePropertiesExists(object key)
        {
            Properties fpi = (Properties)  properties[key];

            if( fpi == null )
            {
                fpi = new Properties();

                properties[key] = fpi;                         
            }

            return fpi;
        }

        #endregion

        #region Interface Method
        bool IExtenderProvider.CanExtend(object obj)
         {
             if (obj is TextBoxBase || obj is TextEdit || obj is LookUpEdit || obj is RadioGroup || obj is DateEdit || obj is TimeEdit || obj is SimpleButton || obj is GridControl  || obj is MemoExEdit || obj is CheckEdit)
                return true;
            else
                return false;
        }
        #endregion

        #region Properties Class

        private class Properties 
        {
            private Control control;

            public Properties( Control _control)
            {
                control = _control;
            }

            public Properties()
            {
            }

            public Control ControlInfo
            {
                set { control = value;}
                get { return control;}
            }

        }

        #endregion
    }
}
