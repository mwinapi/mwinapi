using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace WinternalExplorer
{
    public partial class SearchResultForm : Form
    {
        private readonly MainForm mf;
        private readonly string prefix;
        private readonly Regex regex;
        private Dictionary<string, TreeNode> categoryNodes = new Dictionary<string, TreeNode>();

        public SearchResultForm(MainForm mf, String title, String prefix)
        {
            this.mf = mf;
            InitializeComponent();
            tree.ImageList = mf.TreeImageList;
            this.Text = "Search results: " + title;
            if (prefix.StartsWith("{") && prefix.EndsWith("}"))
            {
                this.regex = new Regex(prefix.Substring(1, prefix.Length - 2));
                prefix = "";
            }
            else
            {
                this.regex = null;
            }
            this.prefix = prefix;
        }

        internal void AddPossibleResult(TreeNodeData data, string text)
        {
            if (!text.StartsWith(prefix)) return;
            if (regex != null && !regex.IsMatch(text)) return;
            if (!categoryNodes.ContainsKey(text))
            {
                categoryNodes[text] = new TreeNode(text, 6, 6);
            }
            TreeNode tn = new TreeNode(data.Name, data.Icon, data.Icon);
            tn.Tag = data;
            categoryNodes[text].Nodes.Add(tn);
        }

        internal void Finish()
        {
            List<TreeNode> cns = new List<TreeNode>(categoryNodes.Values);
            cns.Sort(delegate(TreeNode a, TreeNode b)
            {
                return a.Text.CompareTo(b.Text);
            });
            foreach (TreeNode tn in cns)
            {
                tree.Nodes.Add(tn);
            }
            Show();
        }

        private void tree_DoubleClick(object sender, EventArgs e)
        {
            if (tree.SelectedNode == null) return;
            TreeNode tn = tree.SelectedNode;
            if (tn.Tag != null && tn.Tag is SelectableTreeNodeData)
            {
                mf.DoSelect((SelectableTreeNodeData)tn.Tag, true);
            }
        }
    }
}