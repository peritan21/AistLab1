using System.Windows.Forms;

namespace AistLab
{
    public class TreeNodePlusKol : TreeNode
    {
        private string _nodeName = "";
        public int NodeId { get; set; }

        public string NodeName
        {
            get { return _nodeName; }
            set { _nodeName = value; }
        }

        public int NodePRIZNAK { get; set; }

        public int NodeRTabIndex { get; set; }
    }
}
