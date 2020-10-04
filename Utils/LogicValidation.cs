

namespace CodeFirst_API.Utils
{

    public class LogicValidation
    {
        public bool ValidateIfDataOfNull(object parameter) {

            var isValid = parameter == null;
            return isValid;
        }
    }
}
