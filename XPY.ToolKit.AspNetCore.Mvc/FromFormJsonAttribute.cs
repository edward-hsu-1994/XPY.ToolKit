using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Text;

namespace XPY.ToolKit.AspNetCore.Mvc {
    /// <summary>
    /// 自FormData中的JSON字串欄位轉換模型
    /// </summary>
    public class FromFormJsonAttribute : Attribute, IBindingSourceMetadata, IModelNameProvider {
        /// <summary>
        /// 綁定來源
        /// </summary>
        public BindingSource BindingSource => new BindingSource("Form", "FormJson", true, true);

        /// <summary>
        /// 欄位名稱
        /// </summary>
        public string Name { get; set; }
    }
}
