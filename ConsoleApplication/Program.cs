using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    public class FieldDescription
    {
        public string Name;
        public string TypeName;
        public string DefaultValue;
        public string PropertyName;
        public bool IgnoreSerialization;

        public FieldDescription(string name, string typeName, string defaultValue = "", bool ignoreSerialization = false)
        {
            Name = name;
            TypeName = typeName;
            DefaultValue = defaultValue;
            PropertyName = name.ToUpper()[0] + name.Substring(1);
            IgnoreSerialization = ignoreSerialization;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            CreateScheduledTransactionClass();
        }

        static void CreateProductClass()
        {
            var fields = new List<FieldDescription>();

            fields.Add(new FieldDescription("name", "string"));
            fields.Add(new FieldDescription("description", "string"));            

            CreateModelClass("Product", fields);
        }

        static void CreateAccountClass()
        {
            var fields = new List<FieldDescription>();

            fields.Add(new FieldDescription("name", "string"));
            fields.Add(new FieldDescription("type", "string"));
            fields.Add(new FieldDescription("balance", "decimal"));
            fields.Add(new FieldDescription("address", "Address"));
            fields.Add(new FieldDescription("phone", "string"));
            fields.Add(new FieldDescription("email", "string"));
            fields.Add(new FieldDescription("website", "string"));
            fields.Add(new FieldDescription("parentAccountId", "Guid?"));

            CreateModelClass("Account", fields);
        }

        static void CreateAddressClass()
        {
            var fields = new List<FieldDescription>();

            fields.Add(new FieldDescription("line1", "string"));
            fields.Add(new FieldDescription("line2", "string"));
            fields.Add(new FieldDescription("city", "string"));
            fields.Add(new FieldDescription("state", "string"));
            fields.Add(new FieldDescription("zip", "string"));            

            CreateModelClass("Address", fields);
        }

        static void CreateFrequencyClass()
        {
            var fields = new List<FieldDescription>();

            fields.Add(new FieldDescription("isDaily", "bool"));
            fields.Add(new FieldDescription("isWeekly", "bool"));
            fields.Add(new FieldDescription("isMonthly", "bool"));
            fields.Add(new FieldDescription("value", "int"));
            fields.Add(new FieldDescription("beginDate", "DateTime"));
            fields.Add(new FieldDescription("endDate", "DateTime?"));

            CreateModelClass("Frequency", fields);
        }

        static void CreateReceiptClass()
        {
            var fields = new List<FieldDescription>();

            CreateModelClass("Receipt", fields);
        }

        static void CreateScheduledTransactionClass()
        {
            var fields = new List<FieldDescription>();

            fields.Add(new FieldDescription("name", "string"));
            fields.Add(new FieldDescription("memo", "string"));
            fields.Add(new FieldDescription("frequency", "Frequency"));
            fields.Add(new FieldDescription("fromAccountId", "Guid"));
            fields.Add(new FieldDescription("toAccountId", "Guid"));
            fields.Add(new FieldDescription("details", "ObservableCollection<ScheduledTransactionDetail>", "new ObservableCollection<ScheduledTransactionDetail>()", true));

            CreateModelClass("ScheduledTransaction", fields);
        }

        static void CreateScheduledTransactionDetailClass()
        {
            var fields = new List<FieldDescription>();

            fields.Add(new FieldDescription("amount", "decimal"));
            fields.Add(new FieldDescription("reference", "string"));
            fields.Add(new FieldDescription("scheduledTransactionId", "Guid"));            

            CreateModelClass("ScheduledTransactionDetail", fields);
        }

        static void CreateTransactionClass()
        {
            var fields = new List<FieldDescription>();

            fields.Add(new FieldDescription("date", "DateTime", "DateTime.Now.Date"));
            fields.Add(new FieldDescription("memo", "string"));
            fields.Add(new FieldDescription("receiptId", "Guid?"));
            fields.Add(new FieldDescription("details", "ObservableCollection<TransactionDetail>", "new ObservableCollection<TransactionDetail>()", true));
            fields.Add(new FieldDescription("scheduledTransactionId", "Guid?"));
            fields.Add(new FieldDescription("scheduledTransaction", "ScheduledTransaction", "", true));

            CreateModelClass("Transaction", fields);
        }

        static void CreateTransactionDetailClass()
        {
            var fields = new List<FieldDescription>();

            fields.Add(new FieldDescription("transactionId", "Guid"));
            fields.Add(new FieldDescription("debitAmount", "decimal"));
            fields.Add(new FieldDescription("creditAmount", "decimal"));            
            fields.Add(new FieldDescription("reference", "string"));
            fields.Add(new FieldDescription("accountId", "Guid"));

            CreateModelClass("TransactionDetail", fields);
        }

        static void CreateModelClass(string className, IEnumerable<FieldDescription> fields)
        {
            var writer = System.Console.Out;

            writer.WriteLine("using System;");
            if (fields.Any(t => t.TypeName.Contains("ObservableCollection")))
            {
                writer.WriteLine("using System.Collections.ObjectModel;");
            }
            writer.WriteLine();
            writer.WriteLine("namespace ClassLibrary.Models");
            writer.WriteLine("{");
            writer.WriteLine("\tpublic class {0} : ModelBase", className);
            writer.WriteLine("\t{");
            writer.WriteLine("\t\t#region fields");
            writer.WriteLine();

            foreach (var field in fields)
            {
                if (!string.IsNullOrEmpty(field.DefaultValue))
                {
                    writer.WriteLine("\t\tprivate {0} _{1} = {2};", field.TypeName, field.Name, field.DefaultValue);
                }
                else
                {
                    writer.WriteLine("\t\tprivate {0} _{1};", field.TypeName, field.Name);
                }
            }

            writer.WriteLine();
            writer.WriteLine("\t\t#endregion");
            writer.WriteLine();
            writer.WriteLine("\t\t#region properties");            
            writer.WriteLine();

            foreach (var field in fields)
            {
                if (field.IgnoreSerialization)
                {
                    writer.WriteLine("\t\t[System.Xml.Serialization.XmlIgnore]");
                }

                writer.WriteLine("\t\tpublic {0} {1}", field.TypeName, field.PropertyName);
                writer.WriteLine("\t\t{");
                writer.WriteLine("\t\t\tget {{ return _{0}; }}", field.Name);
                writer.WriteLine("\t\t\tset");
                writer.WriteLine("\t\t\t{");
                writer.WriteLine("\t\t\t\tif (OnPropertyChanging(nameof({0}), _{1}, value))", field.PropertyName, field.Name);
                writer.WriteLine("\t\t\t\t{");
                writer.WriteLine("\t\t\t\t\t_{0} = value;", field.Name);
                writer.WriteLine("\t\t\t\t\tOnPropertyChanged(nameof({0}));", field.PropertyName);
                writer.WriteLine("\t\t\t\t}");
                writer.WriteLine("\t\t\t}");
                writer.WriteLine("\t\t}");
                writer.WriteLine();
            }
            
            writer.WriteLine("\t\t#endregion");
            writer.WriteLine("\t}");
            writer.WriteLine("}");
        }
    }
}
