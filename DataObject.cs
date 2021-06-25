using System;
namespace CVS_String
{
    public class DataObject
    {
        public string FullName;
        public string FirstName;
        public string MiddleName;
        public string LastName;
        public int TransactionNumber;
        public decimal TransactionAmount;
        public DateTime TransactionDate;

        public DataObject(string rowdata)
        {
            string dateString = "1 February 2018";
            DateTime startDate = DateTime.Parse(dateString);
            var dateTime = DateTime.Parse(dateString);
            string[] data = rowdata.Split(',');
            
            this.FullName = data[0].ToUpper();
            var indexOfFirstSpace = FullName.IndexOf(" ");
            this.FirstName = FullName.Substring(0, indexOfFirstSpace);
            var second = FullName.Substring(indexOfFirstSpace + 1);
            var indexOfSecondSpace = second.IndexOf(" ");
            if (indexOfSecondSpace > 0)
            {
                this.MiddleName = second.Substring(0, indexOfSecondSpace);
                this.LastName = second.Substring(indexOfSecondSpace + 1);
            }
            else
            {
                this.LastName = FullName.Substring(indexOfFirstSpace + 1);
            }
            this.TransactionNumber = Convert.ToInt32(data[1]);
            this.TransactionAmount = decimal.Parse(data[2], System.Globalization.NumberStyles.Currency);
            if (!string.IsNullOrEmpty(data[3]))
            {
                TimeSpan ts = new TimeSpan(Convert.ToInt32(data[3]), 0, 0, 0);
                this.TransactionDate = startDate.Subtract(ts);
            }
            else
            {
                this.TransactionDate = DateTime.Now;
            }
           
        }

        public override string ToString()
        {
            string str = $"First Name: {FirstName} \n" +
                 $"Middle Name: {MiddleName} \n" +
                 $"Last Name: {LastName} \n" +
                 $"Transaction Number: {TransactionNumber} \n" +
                 $"Transaction Amount: {TransactionAmount} \n" +
                 $"DateTme: {TransactionDate}";

            return str;
        }
    }
}



