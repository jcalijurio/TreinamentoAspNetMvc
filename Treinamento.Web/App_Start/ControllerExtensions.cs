using System;

namespace Treinamento.Web
{
    public static class ControllerExtensions
    {
        public static TViewModel ToViewModel<TViewModel>(this object dto)
        {
            var vm = Activator.CreateInstance<TViewModel>();
            foreach (var prop in dto.GetType().GetProperties())
            {
                typeof(TViewModel).GetProperty(prop.Name).SetValue(vm, prop.GetValue(dto));
            }
            return vm;
        }
    }
}