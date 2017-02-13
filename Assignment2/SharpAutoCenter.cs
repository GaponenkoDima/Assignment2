//author: Dmytro Gaponenko (200335210)
//date: 12-02-2017
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment2
{
    public partial class SharpAutoCenter : Form


    { 
    


        public Form previousForm;
        // INSTANCE VARIABLES

    double priceStereoSystem = 598.35;
    double priceLeatherInterior = 234.35;
    double priceComputerNavigation = 350.00;
    double priceExteriorStandard = 0;
    double priceExteriorPearlized = 344.12;
    double priceExteriorCustomized = 559.00;
    double taxRate = 0.13;
    private double _val;
        /// <summary>
        /// Default Constructor
        /// </summary>
    public SharpAutoCenter()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This method checks is the input is numeric value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNumeric(string value)
        {
            if (value == null || value is DateTime)
            {
                return false;
            }

            if (value is Double)
            {
                return true;
            }

            try
            {
                if (value is string)
                    Double.Parse(value as string);
                else
                    Double.Parse(value.ToString());
                return true;
            }
            catch { }
            return false;
        }



        /// <summary>
        /// This method controls the aplication closing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SharpAutoCenter_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (BasePriceLabel.Text == "Prix de base :")
            {
                DialogResult result = MessageBox.Show("Êtes-vous sûr?", "Confirmer",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else 
            {

                DialogResult result = MessageBox.Show("Are You Sure?", "Confirm",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (result == DialogResult.OK)
                {
                    Application.Exit();
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        /// <summary>
        /// This method is to show about window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutForm = new AboutBox1();
            aboutForm.ShowDialog();
        }

        //Exit from button
        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// This method is to change font
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //using pre-built Font Dialog option.
            using (FontDialog fd = new FontDialog())
            {
                if (fd.ShowDialog(this) == DialogResult.OK)
                {
                    BasePriceTextBox.Font = fd.Font;
                    AmountDueTextBox.Font = fd.Font;

                }
            }

        }
        /// <summary>
        /// This method is to change color.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ColorDialog cl = new ColorDialog())
            {
                // See if user pressed ok.
                if (cl.ShowDialog(this) == DialogResult.OK)
                {
                    // Set form background to the selected color.
                    BasePriceTextBox.BackColor = cl.Color;
                    AmountDueTextBox.BackColor = cl.Color;
                }
            }
        }
        /// <summary>
        /// This is actual calculation method
        /// </summary>
        private void Calculate()
        {
            //checking all the checkboxes and radio buttons and storing requrired values in variable _val.
            this._val = 0.0;
            if (StereoSystemCheckBox.Checked)
            {
                this._val += priceStereoSystem;
            }
            if (LeatherInteriorCheckBox.Checked)
            {
                this._val += priceLeatherInterior;
            }
            if (ComputerNavigationCheckBox.Checked)
            {
                this._val += priceComputerNavigation;
            }
            if (StandardButton.Checked)
            {
                this._val += priceExteriorStandard;
            }
            if (PearlizedButton.Checked)
            {
                this._val += priceExteriorPearlized;
            }
            if (CustomizedButton.Checked)
            {
                this._val += priceExteriorCustomized;
            }
            //converting the variable to string with 0.00 format
            AdditionalOptionsTextBox.Text = String.Format("{0:0.00}", this._val).ToString();
            //validation
            if (IsNumeric(BasePriceTextBox.Text))
            {
                SubTotalTextBox.Text = (this._val + Convert.ToDouble(BasePriceTextBox.Text)).ToString();
                double SalesTax = (Convert.ToDouble(SubTotalTextBox.Text) * taxRate);
                SalesTaxTextBox.Text = String.Format("{0:0.00}", SalesTax).ToString();

                double total = (Convert.ToDouble(SubTotalTextBox.Text) + Convert.ToDouble(SalesTaxTextBox.Text));
                TotalTextBox.Text = String.Format("{0:0.00}", total).ToString();
                //validation
                if (IsNumeric(TradeInTextBox.Text))
                {

                    double amountDue = (Convert.ToDouble(SubTotalTextBox.Text) - Convert.ToDouble(TradeInTextBox.Text));
                    AmountDueTextBox.Text = String.Format("{0:0.00}", amountDue).ToString();
                }
                else
                {
                    //in case the program running with French language
                    if(BasePriceLabel.Text == "Prix de base :")
                    {
                        MessageBox.Show("Le commerce de valeur est incorrect.");
                    }
                    else
                    MessageBox.Show("Trade in value is incorrect.");

                    TradeInTextBox.Text = "0";
                }
            }
            else
            {
                if (BasePriceLabel.Text == "Prix de base :")
                {
                    MessageBox.Show("Le commerce de valeur est incorrect.");
                }
                else
                MessageBox.Show("Incorrect input. Please use numbers only.");

            }

        }
        private void CalculateButton_Click(object sender, EventArgs e)
        {
            Calculate();
        }

        /// <summary>
        /// This method is to clear all the text boxes
        /// </summary>
        private void Clear()
        {
            BasePriceTextBox.Text = String.Empty;
            AdditionalOptionsTextBox.Text = String.Empty;
            SubTotalTextBox.Text = String.Empty;
            SalesTaxTextBox.Text = String.Empty;
            TotalTextBox.Text = String.Empty;
            TradeInTextBox.Text = "0";
            AmountDueTextBox.Text = String.Empty;
            StereoSystemCheckBox.Checked = false;
            LeatherInteriorCheckBox.Checked = false;
            ComputerNavigationCheckBox.Checked = false;
            StandardButton.Checked = true;
        }
        private void ClearButton_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void CalculateItem_Click(object sender, EventArgs e)
        {
            Calculate();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// English language
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BasePriceLabel.Text = "Base Price :";
            AdditionalOptionsLabel.Text = "Additional Options :";
            SubTotalLabel.Text = "SubTotal :";
            SalesTaxLabel.Text = "Sales Tax (13%) :";
            TotalLabel.Text = "Total :";
            TradeInLabel.Text = "Trade-in Allowance :";
            AmmountDueLabel.Text = "Amount Due";
            CalculateButton.Text = "Calculate";
            ClearButton.Text = "Clear";
            ExitButton.Text = "Exit";
            AdditionalItemsBox.Text = "Additional Items";
            StereoSystemCheckBox.Text = "Stereo System";
            LeatherInteriorCheckBox.Text = "Leather Interior";
            ComputerNavigationCheckBox.Text = "Computer Navigation";
            ExteriorFinishBox.Text = "Exterior Finish";
            StandardButton.Text = "Standard";
            PearlizedButton.Text = "Pearlized";
            CustomizedButton.Text = "Customized Detailing";
            fileToolStripMenuItem.Text = "File";
            exitToolStripMenuItem.Text = "Exit";
            editToolStripMenuItem.Text = "Edit";
            CalculateItem.Text = "Calculate";
            clearToolStripMenuItem.Text = "Clear";
            fontToolStripMenuItem.Text = "Font";
            colorToolStripMenuItem.Text = "Color";
            languageToolStripMenuItem.Text = "Language";
            englishToolStripMenuItem.Text = "English";
            frenchToolStripMenuItem.Text = "French";
            helpToolStripMenuItem.Text = "Help";
            aboutToolStripMenuItem.Text = "About";

        }
        /// <summary>
        /// French language
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frenchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BasePriceLabel.Text = "Prix de base :";
            AdditionalOptionsLabel.Text = "Options additionelles :";
            SubTotalLabel.Text = "Sum :";
            SalesTaxLabel.Text = "Taxe de vente (13%) :";
            TotalLabel.Text = "Total :";
            TradeInLabel.Text = "Indemnité de reprise :";
            AmmountDueLabel.Text = "Montant dû";
            CalculateButton.Text = "Calculer";
            ClearButton.Text = "Clair";
            ExitButton.Text = "Sortie";
            AdditionalItemsBox.Text = "Des éléments supplémentaires";
            StereoSystemCheckBox.Text = "Système stéréo";
            LeatherInteriorCheckBox.Text = "Intérieur en cuir";
            ComputerNavigationCheckBox.Text = "Navigation par ordinateur";
            ExteriorFinishBox.Text = "Finition extérieure";
            StandardButton.Text = "La norme";
            PearlizedButton.Text = "Perlé";
            CustomizedButton.Text = "Détail personnalisé";
            fileToolStripMenuItem.Text = "Fichier";
            exitToolStripMenuItem.Text = "Exit";
            editToolStripMenuItem.Text = "Modifier";
            CalculateItem.Text = "Calculer";
            clearToolStripMenuItem.Text = "Clair";
            fontToolStripMenuItem.Text = "Police de caractère";
            colorToolStripMenuItem.Text = "Couleur";
            languageToolStripMenuItem.Text = "La langue";
            englishToolStripMenuItem.Text = "Anglais";
            frenchToolStripMenuItem.Text = "Français";
            helpToolStripMenuItem.Text = "Aidez";
            aboutToolStripMenuItem.Text = "Sur";
        }


    }
}
