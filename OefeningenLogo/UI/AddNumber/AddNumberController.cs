using System.Text.RegularExpressions;
using OefeningenLogo.Oefeningen;

namespace OefeningenLogo.UI.AddNumber
{
    public class AddNumberController : IAddNumberController
    {
        private readonly IAddNumberWindow _window;
        private INumberDefinition _number;
        private string _name;
        private int _decimals;
        private int _maxvalue;
        private int _minvalue;
        private bool _decimalsValid;
        private bool _maxvalueValid;
        private bool _minvalueValid;
        private bool _nameValid;

        public AddNumberController(IAddNumberWindow window)
        {
            _window = window;
        }

        public INumberDefinition ShowWindow(IWindow parent)
        {
            _name = string.Empty;
            _decimals = 0;
            _minvalue = 0;
            _maxvalue = 0;
            _decimalsValid = false;
            _minvalueValid = false;
            _maxvalueValid = false;
            _nameValid = false;

            _window.SaveButtonClicked += SaveButtonClicked;
            _window.CancelButtonClicked += CancelButtonClicked;
            _window.NameChanged += NameChanged;
            _window.MinvalueChanged += MinvalueChanged;
            _window.MaxvalueChanged += MaxvalueChanged;
            _window.DecimalsChanged += DecimalsChanged;

            _window.ShowDialog(parent);

            _window.SaveButtonClicked -= SaveButtonClicked;
            _window.CancelButtonClicked -= CancelButtonClicked;
            _window.NameChanged -= NameChanged;
            _window.MinvalueChanged -= MinvalueChanged;
            _window.MaxvalueChanged -= MaxvalueChanged;
            _window.DecimalsChanged -= DecimalsChanged;

            return _number;
        }

        private void DecimalsChanged(string decimals)
        {
            _decimalsValid = int.TryParse(decimals, out _decimals);
            _window.DecimalsValid(_decimalsValid);
        }

        private void MaxvalueChanged(string maxvalue)
        {
            _maxvalueValid = int.TryParse(maxvalue, out _maxvalue);
            _window.MaxvalueValid(_maxvalueValid);
        }

        private void MinvalueChanged(string minvalue)
        {
            _minvalueValid = int.TryParse(minvalue, out _minvalue);
            _window.MinvalueValid(_minvalueValid);
        }

        private void NameChanged(string name)
        {
            var regex = new Regex(@"\{\d+\}");
            var match = regex.Match(name);
            _nameValid = match.Success;
            _window.NameValid(_nameValid);
            _name = name;
        }

        private void CancelButtonClicked()
        {
            _window.Close();
        }

        private void SaveButtonClicked()
        {
            if (!IsValid()) 
                return;
            
            _number = new NumberDefinition(_name, _minvalue, _maxvalue, _decimals);
            _window.Close();
        }

        private bool IsValid()
        {
            if ((!_minvalueValid || !_maxvalueValid || !_decimalsValid || !_nameValid))
            {
                _window.DecimalsValid(_decimalsValid);
                _window.MinvalueValid(_minvalueValid);
                _window.MaxvalueValid(_maxvalueValid);
                _window.NameValid(_nameValid);
                _window.ValidationIssuesPresent();
                return false;
            }
            return true;
        }
    }
}