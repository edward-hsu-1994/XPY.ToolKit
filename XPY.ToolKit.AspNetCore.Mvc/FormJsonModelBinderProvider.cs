using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Text;

namespace XPY.ToolKit.AspNetCore.Mvc {
    /// <summary>
    /// FormData JSON模型綁定器提供者
    /// </summary>
    public class FormJsonModelBinderProvider : IModelBinderProvider {
        public IModelBinder GetBinder(ModelBinderProviderContext context) {
            if (context == null) throw new ArgumentNullException(nameof(context));

            if (context.BindingInfo?.BindingSource?.DisplayName == "FormJson") {
                return new FormJsonModelBinder();
            }

            return null;
        }
    }
}
