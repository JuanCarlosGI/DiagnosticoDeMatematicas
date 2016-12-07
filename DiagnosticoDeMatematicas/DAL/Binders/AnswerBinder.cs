namespace DiagnosticoDeMatematicas.DAL.Binders
{
    using System;
    using System.Web.Mvc;
    using Models;

    /// <summary>
    /// Binder in charge of creating different subclasses of AnswerAbstract
    /// </summary>
    public class AnswerBinder : DefaultModelBinder
    {
        /// <summary>
        /// Creates the object of the subclass.
        /// </summary>
        /// <param name="controllerContext">The controller context.</param>
        /// <param name="bindingContext">The binding context.</param>
        /// <param name="modelType">The type of model that is being created.</param>
        /// <returns>The created object.</returns>
        protected override object CreateModel(ControllerContext controllerContext, ModelBindingContext bindingContext, Type modelType)
        {
            if (modelType == typeof(AnswerAbstract))
            {
                string typeName = bindingContext.ValueProvider.GetValue(bindingContext.ModelName + ".type").AttemptedValue;
                Type instantiationType = Type.GetType(typeName);

                if (instantiationType != null)
                {
                    var obj = Activator.CreateInstance(instantiationType);
                    bindingContext.ModelMetadata = ModelMetadataProviders.Current.GetMetadataForType(() => obj, instantiationType);
                    bindingContext.ModelMetadata.Model = obj;
                    return obj;
                }
            }

            return base.CreateModel(controllerContext, bindingContext, modelType);
        }
    }
}