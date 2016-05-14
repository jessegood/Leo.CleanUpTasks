namespace Leo.CleanUpTasks.Contracts
{
    using PresentationControls;
    using System;
    using System.Diagnostics.Contracts;
    using System.Windows.Forms;

    [ContractClassFor(typeof(IConversionFileView))]
    internal abstract class IConversionFileViewContract : IConversionFileView
    {
        public BindingSource BindingSource
        {
            get
            {
                Contract.Ensures(Contract.Result<BindingSource>() != null);
                Contract.Ensures(Contract.Result<BindingSource>().List != null);

                return default(BindingSource);
            }
        }

        public CheckBox CaseSensitive
        {
            get
            {
                Contract.Ensures(Contract.Result<CheckBox>() != null);
                return default(CheckBox);
            }
        }

        public Button ClearFilter
        {
            get
            {
                Contract.Ensures(Contract.Result<Button>() != null);
                return default(Button);
            }
        }

        public GroupBox ColumnFilter
        {
            get
            {
                Contract.Ensures(Contract.Result<GroupBox>() != null);
                return default(GroupBox);
            }
        }

        public TextBox Description
        {
            get
            {
                Contract.Ensures(Contract.Result<TextBox>() != null);
                return default(TextBox);
            }
        }

        public DialogResult DialogResult { get; set; }

        public CheckBox EmbeddedTags
        {
            get
            {
                Contract.Ensures(Contract.Result<CheckBox>() != null);
                return default(CheckBox);
            }
        }

        public ErrorProvider ErrorProvider
        {
            get
            {
                Contract.Ensures(Contract.Result<ErrorProvider>() != null);
                return default(ErrorProvider);
            }
        }

        public TextBox Filter
        {
            get
            {
                Contract.Ensures(Contract.Result<TextBox>() != null);
                return default(TextBox);
            }
        }

        public Form Form
        {
            get
            {
                Contract.Ensures(Contract.Result<Form>() != null);
                return default(Form);
            }
        }

        public DataGridView Grid
        {
            get
            {
                Contract.Ensures(Contract.Result<DataGridView>() != null);
                Contract.Ensures(Contract.Result<DataGridView>().Columns != null);
                return default(DataGridView);
            }
        }

        public CheckBox IgnoreTags
        {
            get
            {
                Contract.Ensures(Contract.Result<CheckBox>() != null);
                return default(CheckBox);
            }
        }

        public CheckBox Placeholder
        {
            get
            {
                Contract.Ensures(Contract.Result<CheckBox>() != null);
                return default(CheckBox);
            }
        }

        public CheckBox Regex
        {
            get
            {
                Contract.Ensures(Contract.Result<CheckBox>() != null);
                return default(CheckBox);
            }
        }

        public TextBox Replace
        {
            get
            {
                Contract.Ensures(Contract.Result<TextBox>() != null);
                return default(TextBox);
            }
        }

        public Button SaveAsButton
        {
            get
            {
                Contract.Ensures(Contract.Result<Button>() != null);
                return default(Button);
            }
        }

        public Button SaveButton
        {
            get
            {
                Contract.Ensures(Contract.Result<Button>() != null);
                return default(Button);
            }
        }
        public string SavedFilePath
        {
            get
            {
                Contract.Ensures(!string.IsNullOrEmpty(Contract.Result<string>()));
                return default(string);
            }

            set
            {
                Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(value));
            }
        }

        public TextBox Search
        {
            get
            {
                Contract.Ensures(Contract.Result<TextBox>() != null);
                return default(TextBox);
            }
        }

        public CheckBox StrConv
        {
            get
            {
                Contract.Ensures(Contract.Result<CheckBox>() != null);
                return default(CheckBox);
            }
        }
        public CheckBox TagPair
        {
            get
            {
                Contract.Ensures(Contract.Result<CheckBox>() != null);
                return default(CheckBox);
            }
        }

        public CheckBox ToLower
        {
            get
            {
                Contract.Ensures(Contract.Result<CheckBox>() != null);
                return default(CheckBox);
            }
        }

        public CheckBox ToUpper
        {
            get
            {
                Contract.Ensures(Contract.Result<CheckBox>() != null);
                return default(CheckBox);
            }
        }

        public CheckBoxComboBox VbStrConv
        {
            get
            {
                Contract.Ensures(Contract.Result<CheckBoxComboBox>() != null);
                Contract.Ensures(Contract.Result<CheckBoxComboBox>().CheckBoxItems != null);
                Contract.Ensures(Contract.Result<CheckBoxComboBox>().Items != null);
                return default(CheckBoxComboBox);
            }
        }

        public CheckBox WholeWord
        {
            get
            {
                Contract.Ensures(Contract.Result<CheckBox>() != null);
                return default(CheckBox);
            }
        }

        public void Dispose()
        {
        }

        public void InitializeUI()
        {
        }

        public void SetPresenter(IConversionFileViewPresenter presenter)
        {
            Contract.Requires<ArgumentNullException>(presenter != null);
        }

        public DialogResult ShowDialog()
        {
            return default(DialogResult);
        }
    }
}