using FormSorting.Application.DefaultService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sorting
{
    public partial class MainForm : Form
    {
        QuickSortAppService qsAppService = new QuickSortAppService();
        BubbleSortAppService bsAppService = new BubbleSortAppService();
        MergeSortAppService msAppService = new MergeSortAppService();
        GCFSortAppService gcfAppService = new GCFSortAppService();

        BindingSource bsQS = new BindingSource();
        BindingSource bsBS = new BindingSource();
        BindingSource bsMS = new BindingSource();
        BindingSource bsGCF = new BindingSource();

        public MainForm()
        {
            InitializeComponent();
        }


        public async void QuickSortThread(int[] input)
        {
            bsQS.DataSource = await qsAppService.getQuickSort(input, 0, input.Length - 1);
            dgQuickSort.DataSource = bsQS;
        }

        public async void BubbleSortThread(int[] input)
        {
            bsBS.DataSource = await bsAppService.getBubbleSort(input);
            dgBubbleSort.DataSource = bsBS;
        }
        public async void MergeSortThread(int[] input)
        {
            bsMS.DataSource = await msAppService.getMergeSort(input);
            dgMergeSort.DataSource = bsMS;
        }
        public async void GCFSortThread(int[] input)
        {
            bsGCF.DataSource = await gcfAppService.getGCFSort(input);
            dgGCFSort.DataSource = bsGCF;
        }
        private void btnSort_Click(object sender, EventArgs e)
        {
            string inputStr = txtInput.Text;
            string[] subInputStr = inputStr.Split(',');
            int[] input = new int[subInputStr.Length];
            int i = 0;
            foreach (var sub in subInputStr)
            {
                input[i] = Convert.ToInt32(sub);
                i++;
            }

            QuickSortThread(input);
            BubbleSortThread(input);
            MergeSortThread(input);
            GCFSortThread(input);
        }
    }
}
