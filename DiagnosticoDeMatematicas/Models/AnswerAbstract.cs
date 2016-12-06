namespace DiagnosticoDeMatematicas.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Web.Mvc;

    /// <summary>
    /// Class representing an abstract answer to a given question.
    /// </summary>
    public abstract class AnswerAbstract
    {
        /// <summary>
        /// Gets or sets the ID of the response it belongs to.
        /// </summary>
        [Key, Column(Order = 0)]
        public int ResponseId { get; set; }

        /// <summary>
        /// Gets or sets the ID of the question it is answering.
        /// </summary>
        [Key, Column(Order = 1)]
        public int QuestionId { get; set; }

        /// <summary>
        /// Gets or sets the response it belongs to.
        /// </summary>
        [ForeignKey("ResponseId")]
        public virtual Response Response { get; set; }

        /// <summary>
        /// Gets or sets the question it is answering.
        /// </summary>
        [ForeignKey("QuestionId")]
        public virtual QuestionAbstract Question { get; set; }

        /// <summary>
        /// Gets a value indicating whether the answer is correct.
        /// </summary>
        [Display(Name = "Es correcta")]
        public abstract bool IsCorrect { get; }
    }

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