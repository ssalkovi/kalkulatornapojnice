public void IzracunajOtpor(object sender, DataGridViewCellEventArgs e)
        {
            double otpor_ukupni = 0.0;
            foreach(DataGridViewRow redak in dataGridView1.Rows)
            {
                double otpor = Convert.ToDouble(redak.Cells["colOtpor"].Value);
                if (otpor == 0) continue;
                otpor_ukupni += Math.Pow(otpor, -1);
            }

            try
            {
                numudUkupniOtpor.Value = Convert.ToDecimal(Math.Pow(otpor_ukupni, -1));
            } catch(OverflowException) {
                numudUkupniOtpor.Value = 0.0m;
            }
        }

        private void IzbrisiOtpor(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == dataGridView1.Columns["colIzbrisi"].Index)
            {
                try
                {
                    dataGridView1.Rows.RemoveAt(e.RowIndex);
                }
                catch (InvalidOperationException) { }
                IzracunajOtpor(sender, e);
            }
        }