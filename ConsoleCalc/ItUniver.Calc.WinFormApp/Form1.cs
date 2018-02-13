using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConsoleCalc;
using ItUniver.Calc.Core.Interfaces;

namespace ItUniver.Calc.WinFormApp
{
    public partial class Form1 : Form
    {
        private ConsoleCalc.Calc calc { get; set; }

        public Form1()
        {
            InitializeComponent();
            btnCalc.Enabled = false;
            btnReset.Enabled = false;

            #region Загрузка операций
            calc = new ConsoleCalc.Calc();
            cbOperation.Items.Clear();
            var operations = calc.GetOperNames();
            //var superOperations = operations.OfType<SuperOperation>();

            //cbOperation.Items.AddRange(superOperations.Select(s => s.OwnerName).ToArray());
            //cbOperation.Items.AddRange(operations
            //    .Except(superOperations)
            //    .Select(s => s.Name)
            //    .ToArray());

            cbOperation.Items.AddRange(operations);
            #endregion

            #region Загрузка истории
            lbHistory.Items.AddRange(MyHelper.GetAll());
            #endregion
        }

        private void btnLuck_Click(object sender, EventArgs e)
        {
            //tbResult.Text = "Успех!";
            Random random = new Random();
            int rnd = random.Next(0, cbOperation.Controls.Count);
            var operations = calc.GetOperNames();
            cbOperation.SelectedText = operations[rnd];
            tbInput.Text = "12 34 78";
            btnCalc_Click(sender, e);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            tbResult.Clear();
            tbResult.Enabled = false;
            tbInput.Clear();
            tbInput.Enabled = false;
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            //Получить операцию
            var oper = $"{cbOperation.SelectedItem}";

            //Получить данные
            var args = tbInput.Text.Trim().Split(' ').Select(str => Convert.ToDouble(str));
            //Вычислить результат
            var result = calc.Exec(oper, args.ToArray());
            //Показать результат
            tbResult.Text = $"{result}";

            // добавить в историю БД
            MyHelper.AddToHistoty(oper, args.ToArray(), result);
            //добавить в историю на форму
            lbHistory.Items.Clear();
            lbHistory.Items.AddRange(MyHelper.GetAll());
        }

        private void cbOperation_TextChanged(object sender, EventArgs e)
        {
            if (cbOperation.Text != "")
            {
                tbInput.Enabled = true;
            }
        }

        private void tbInput_TextChanged(object sender, EventArgs e)
        {
            if (tbInput.Text != null)
            {
                tbResult.Enabled = true;
                btnCalc.Enabled = true;
                btnReset.Enabled = true;
            }
        }

        private void tbInput_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                btnCalc_Click(sender, e);
            }
        }
    }
}
