using System;
using System.Collections.Generic;
using DiagnosticoDeMatematicas.Models;

namespace DiagnosticoDeMatematicas.DAL
{
    public class SiteInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<SiteContext>
    {
        protected override void Seed(SiteContext context)
        {
            var admin = new User
            {
                Role = Role.Administrador,
                FirstName = "Juan Carlos",
                LastName = "Guzman",
                Password = "admin",
                DateOfBirth = DateTime.Now,
                Email = "jcgi@admin.com",
                Gender = Gender.Masculino,
                Interest = Scale.Extremadamente,
                Facility = Scale.Extremadamente,
                Liking = Scale.Extremadamente
            };

            context.Users.Add(admin);
            context.SaveChanges();

            var exam = new Exam
            {
                ID = 1,
                Name = "Aritmetica",
                Description = "Este es un examen de aritmetica que permite el desarrollo de habilidades basicas matematicas.",
                Active = true
            };

            context.Exams.Add(exam);
            context.SaveChanges();

            var questions = new List<Question>();
            var variables = new List<Variable>();
            var ranges = new List<Range>();

            questions.Add(new Question
            {
                ID = 1,
                ExamID = 1,
                Description = "Realiza la siguiente operación aritmétca y elige la opción con la respuesta.\\[" +
                "%n+\\frac{|%n-1|}{%n}" + "\\]",
                OptionA = "\\(\\dfrac{|%n*%n+%n-1|}{%n}\\)",
                OptionACorrect = true,
                OptionAFeedback = "Correcto",
                OptionB = "\\(\\dfrac{|2*%n-1|}{%n}\\)",
                OptionBCorrect = false,
                OptionBFeedback = "Suma numeradores y deja el mismo denominador.",
                OptionC = "\\(\\dfrac{|%n-1|}{1}\\)",
                OptionCCorrect = false,
                OptionCFeedback = "Cancela numerador con denominador.",
                OptionD = "\\(\\dfrac{|2*%n-1|}{|%n+1|}\\)",
                OptionDCorrect = false,
                OptionDFeedback = "Suma numeradores y suma denominadores."
            });
            variables.Add(new Variable { QuestionID = 1, Symbol = "n" });
            ranges.Add(new Range { QuestionId = 1, Symbol = "n", ID = 1, Minimum = 3, Maximum = 12 });

            questions.Add(new Question
            {
                ID = 2,
                ExamID = 1,
                Description = "Realiza la operación aritmética y elige la opción que muestra el resultado. \\[" +
                "\\dfrac{1}{%n} - \\dfrac{%n}{|%n+1|}" + "\\]",
                OptionA = "\\(\\dfrac{|1+%n-%n*%n|}{|%n*%n+%n|}\\)",
                OptionACorrect = true,
                OptionAFeedback = "Correcto",
                OptionB = "\\(\\dfrac{|1-%n|}{|%n*%n+%n|}\\)",
                OptionBCorrect = false,
                OptionBFeedback = "Resta numeradores y multiplica denominadores.",
                OptionC = "\\(-\\dfrac{1}{|%n+1|}\\)",
                OptionCCorrect = false,
                OptionCFeedback = "Cancela numerador con denominador (como un producto).",
                OptionD = "\\(\\dfrac{|1-%n|}{|2*%n+1|}\\)",
                OptionDCorrect = false,
                OptionDFeedback = "Resta numeradores y suma denominadores"
            });
            variables.Add(new Variable { QuestionID = 2, Symbol = "n" });
            ranges.Add(new Range { QuestionId = 2, Symbol = "n", ID = 2, Minimum = 3, Maximum = 12 });

            questions.Add(new Question
            {
                ID = 3,
                ExamID = 1,
                Description = "Realiza la operación aritmética indicada y escoge la opción con su resultado. \\[" +
                "\\left ( \\dfrac{1}{%n} \\right )\\left ( \\dfrac{|3*%n|}{13} \\right )" + "\\]",
                OptionA = "\\(\\dfrac{3}{13}\\)",
                OptionACorrect = true,
                OptionAFeedback = "Correcto",
                OptionB = "\\(\\dfrac{|3*%n+1|}{|%n+13|}\\)",
                OptionBCorrect = false,
                OptionBFeedback = "Suma numeradores y suma denominadores",
                OptionC = "\\(\\dfrac{13}{|3*%n*%n|}\\)",
                OptionCCorrect = false,
                OptionCFeedback = "Cruza productos como si fuese división.",
                OptionD = "\\(\\dfrac{|3*%n+1|}{|13*%n|}\\)",
                OptionDCorrect = false,
                OptionDFeedback = "Suma numeradores y multiplica denominadores."
            });
            variables.Add(new Variable { QuestionID = 3, Symbol = "n" });
            ranges.Add(new Range { QuestionId = 3, Symbol = "n", ID = 3, Minimum = 2, Maximum = 11 });

            questions.Add(new Question
            {
                ID = 4,
                ExamID = 1,
                Description = "Realiza la operación señalada y elige la opción que meustra el resultado correcto. \\[" +
                "\\left ( %n \\sqrt{%n} \\right )^{2}" + "\\]",
                OptionA = "\\(|%n*%n*%n|\\)",
                OptionACorrect = true,
                OptionAFeedback = "Correcto",
                OptionB = "\\(|%n*%n|\\)",
                OptionBCorrect = false,
                OptionBFeedback = "Olvida elevar al cuadrado al valor libre",
                OptionC = "\\(|%n*%n|\\sqrt{%n}\\)",
                OptionCCorrect = false,
                OptionCFeedback = "Olvida elevar al cuadrado el radical.",
                OptionD = "\\(\\sqrt{|%n*%n*%n|}\\)",
                OptionDCorrect = false,
                OptionDFeedback = "Realiza operación dentro del radical."
            });
            variables.Add(new Variable { QuestionID = 4, Symbol = "n" });
            ranges.Add(new Range { QuestionId = 4, Symbol = "n", ID = 4, Minimum = 2, Maximum = 3 });
            ranges.Add(new Range { QuestionId = 4, Symbol = "n", ID = 5, Minimum = 5, Maximum = 8 });
            ranges.Add(new Range { QuestionId = 4, Symbol = "n", ID = 6, Minimum = 10, Maximum = 10 });

            questions.Add(new Question
            {
                ID = 5,
                ExamID = 1,
                Description = "Entre las opciones dadas abajo, elige la que es equivalente a la siguiente: \\[" +
                "\\left ( x^{2} + |%n*%n| \\right )^{-2}" + "\\]",
                OptionA = "\\(\\dfrac{1}{\\left ( x^{2} + |%n*%n|\\right )^{2}}\\)",
                OptionACorrect = true,
                OptionAFeedback = "Correcto",
                OptionB = "\\(\\dfrac{1}{x^{4} + |%n*%n|^{2}}\\)",
                OptionBCorrect = false,
                OptionBFeedback = "Error binomio al cuadrado igual a suma de los cuadrados de cada término",
                OptionC = "\\(-\\left ( x^{2} + |%n*%n|\\right )^{2}\\)",
                OptionCCorrect = false,
                OptionCFeedback = "Error interpretación de signo negativo en exponente.",
                OptionD = "\\(x^{-4} + |%n*%n|^{-2}\\)",
                OptionDCorrect = false,
                OptionDFeedback = "Error distribuir el exponente en cada término."
            });
            variables.Add(new Variable { QuestionID = 5, Symbol = "n" });
            ranges.Add(new Range { QuestionId = 5, Symbol = "n", ID = 7, Minimum = 2, Maximum = 10 });

            questions.Add(new Question
            {
                ID = 6,
                ExamID = 1,
                Description = "Entre las siguiente opciones elige la que es equivalente a la expresión algebraica. \\[" +
                "\\sqrt{x^{2} + |%n*%n|}" + "\\]",
                OptionA = "\\(\\left (x^{2} + |%n*%n|\\right )^{1/2}\\)",
                OptionACorrect = true,
                OptionAFeedback = "Correcto",
                OptionB = "\\(\\sqrt{\\left (x+%n\\right )\\left (x-%n\\right )}\\)",
                OptionBCorrect = false,
                OptionBFeedback = "Aplica producto notable de diferencia de cuadrados en una suma de cuadrados",
                OptionC = "\\(x+%n\\)",
                OptionCCorrect = false,
                OptionCFeedback = "Distribuye el radical en cada término y cancela el cuadrado con el radical.",
                OptionD = "\\(\\sqrt{\\left (x+%n\\right )^{2}}\\)",
                OptionDCorrect = false,
                OptionDFeedback = "Producto notable de binomio al cuadrado confundido con suma de cuadrados de cada término."
            });
            variables.Add(new Variable { QuestionID = 6, Symbol = "n" });
            ranges.Add(new Range { QuestionId = 6, Symbol = "n", ID = 8, Minimum = 1, Maximum = 10 });

            questions.Add(new Question
            {
                ID = 7,
                ExamID = 1,
                Description = "Simplifica la expresión dada en seguida y selecciona la opción que le corresponde \\[" +
                "\\left (\\dfrac{%nab^{|%n+1|}}{b^{%n}}\\right )^{-1}" + "\\]",
                OptionA = "\\(\\dfrac{1}{%nab}\\)",
                OptionACorrect = true,
                OptionAFeedback = "Correcto",
                OptionB = "\\(-%nab\\)",
                OptionBCorrect = false,
                OptionBFeedback = "Exponente negativo confundido con cambio de signo.",
                OptionC = "\\(\\dfrac{%nab}{1}\\)",
                OptionCCorrect = false,
                OptionCFeedback = "No opera el exponente negativo.",
                OptionD = "\\(\\dfrac{%n}{ab}\\)",
                OptionDCorrect = false,
                OptionDFeedback = "Opera el exponente negativo sólo a las letras y no a los números."
            });
            variables.Add(new Variable { QuestionID = 7, Symbol = "n" });
            ranges.Add(new Range { QuestionId = 7, Symbol = "n", ID = 9, Minimum = 1, Maximum = 10 });

            questions.Add(new Question
            {
                ID = 8,
                ExamID = 1,
                Description = "Simplifica la expresión con radicales dada enseguida y elcoge la opción que la muestra. \\[" +
                "\\sqrt{x^{|2*%n|}y^{|19-2*%n|}}" + "\\]",
                OptionA = "\\(x^{%n}y^{|9-%n|}\\sqrt{y}\\)",
                OptionACorrect = true,
                OptionAFeedback = "Correcto",
                OptionB = "\\(x^{|2*%n|}y^{|18-2*%n|}\\sqrt{y}\\)",
                OptionBCorrect = false,
                OptionBFeedback = "No divide entre 2 el exponente ni de 'x' ni de 'y' al extraer del radical.",
                OptionC = "\\(x^{%n}y^{|18-2*%n|}\\sqrt{y}\\)",
                OptionCCorrect = false,
                OptionCFeedback = "No divide entre 2 el exponente de 'y' al extraer del radical.",
                OptionD = "\\(x^{|2*%n|}y^{|9-%n|}\\sqrt{y}\\)",
                OptionDCorrect = false,
                OptionDFeedback = "No divide entre 2 el exponente de 'x' al extraer del radical."
            });
            variables.Add(new Variable { QuestionID = 8, Symbol = "n" });
            ranges.Add(new Range { QuestionId = 8, Symbol = "n", ID = 10, Minimum = 2, Maximum = 7 });

            foreach ( var question in questions)
            {
                context.Questions.Add(question);
            }
            context.SaveChanges();

            foreach (var variable in variables)
            {
                context.Variables.Add(variable);
            }
            context.SaveChanges();

            foreach (var range in ranges)
            {
                context.Ranges.Add(range);
            }
            context.SaveChanges();
        }
    }
}