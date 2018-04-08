using System.ComponentModel;

namespace ViewModel
{
    public interface IValidatable : IDataErrorInfo
    {
        /// <summary>
        /// Gets if the entiy is valid
        /// </summary>
        bool IsValid { get; }
    }
}
