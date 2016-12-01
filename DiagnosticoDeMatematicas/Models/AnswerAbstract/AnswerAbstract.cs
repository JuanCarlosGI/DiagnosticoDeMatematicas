using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace DiagnosticoDeMatematicas.Models
{
    public abstract class AnswerAbstract
    {
        [Key, Column(Order = 0)]
        public int ResponseId { get; set; }

        [Key, Column(Order = 1)]
        public int QuestionId { get; set; }

        [ForeignKey("ResponseId")]
        public virtual Response Response { get; set; }

        [ForeignKey("QuestionId")]
        public virtual QuestionAbstract Question { get; set; }

        [Display(Name = "Es correcta")]
        public abstract bool IsCorrect { get; }
    }

    public class AnswerBinder : DefaultModelBinder
    {
        protected override object CreateModel(ControllerContext controllerContext, ModelBindingContext bindingContext, Type modelType)
        {
            if (modelType.Equals(typeof(AnswerAbstract)))
            {
                // Todo: Add support for different types
                Type instantiationType = typeof(SingleSelectionAnswer);
                var obj = Activator.CreateInstance(instantiationType);
                bindingContext.ModelMetadata = ModelMetadataProviders.Current.GetMetadataForType(() => obj, instantiationType);
                bindingContext.ModelMetadata.Model = obj;
                return obj;
            }

            return base.CreateModel(controllerContext, bindingContext, modelType);
        }

        protected override void BindProperty(ControllerContext controllerContext, ModelBindingContext bindingContext, PropertyDescriptor propertyDescriptor)
        {
            base.BindProperty(controllerContext, bindingContext, propertyDescriptor);
        }
    }
}