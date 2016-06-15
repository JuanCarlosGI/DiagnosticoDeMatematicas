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

            var exams = new List<Exam>();

            exams.Add(new Exam
            {
                ID = 1,
                Name = "Números",
                Description = "Este es un examen de aritmetica que permite el desarrollo de habilidades basicas matematicas.",
                Active = true
            });

            exams.Add(new Exam
            {
                ID = 2,
                Name = "Fórmulas",
                Description = "Este es un examen de aritmetica que permite el desarrollo de habilidades basicas matematicas.",
                Active = true
            });

            foreach(var exam in exams)
            {
                context.Exams.Add(exam);
            }
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
                ExamID = 2,
                Description = "Entre las opciones dadas abajo, elige la que es equivalente a la siguiente: \\[" +
                "\\left ( x^{2} + |%n*%n| \\right )^{-2}" + "\\]",
                OptionA = "\\(\\dfrac{1}{\\left ( x^{2} + |%n*%n|\\right )^{2}}\\)",
                OptionACorrect = true,
                OptionAFeedback = "Correcto",
                OptionB = "\\(\\dfrac{1}{x^{4} + |%n*%n|^{2}}\\)",
                OptionBCorrect = false,
                OptionBFeedback = "Realiza suma de los cuadrados de cada término",
                OptionC = "\\(-\\left ( x^{2} + |%n*%n|\\right )^{2}\\)",
                OptionCCorrect = false,
                OptionCFeedback = "Interpretación incorrecta de signo negativo en exponente.",
                OptionD = "\\(x^{-4} + |%n*%n|^{-2}\\)",
                OptionDCorrect = false,
                OptionDFeedback = "Distribuye el exponente en cada término."
            });
            variables.Add(new Variable { QuestionID = 5, Symbol = "n" });
            ranges.Add(new Range { QuestionId = 5, Symbol = "n", ID = 7, Minimum = 2, Maximum = 10 });

            questions.Add(new Question
            {
                ID = 6,
                ExamID = 2,
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
                ExamID = 2,
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
                ExamID = 2,
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

            questions.Add(new Question
            {
                ID = 9,
                ExamID = 1,
                Description = "Realiza la operación y selecciona su resultado. \\[" +
                "1 + \\dfrac{1}{%n}" + "\\]",
                OptionA = "\\(\\dfrac{|%n+1|}{%n}\\)",
                OptionACorrect = true,
                OptionAFeedback = "Correcto",
                OptionB = "\\(\\dfrac{2}{%n}\\)",
                OptionBCorrect = false,
                OptionBFeedback = "Suma numeradores y deja el mismo denominador.",
                OptionC = "\\(\\dfrac{2}{|1+%n|}\\)",
                OptionCCorrect = false,
                OptionCFeedback = "Suma numeradores y suma denominadores.",
                OptionD = "\\(\\dfrac{%n}{|%n+1|}\\)",
                OptionDCorrect = false,
                OptionDFeedback = "Confunde posición de numerador y denominador."
            });
            variables.Add(new Variable { QuestionID = 9, Symbol = "n" });
            ranges.Add(new Range { QuestionId = 9, Symbol = "n", ID = 11, Minimum = 3, Maximum = 10 });

            questions.Add(new Question
            {
                ID = 10,
                ExamID = 1,
                Description = "Realiza la operación indicada y selecciona la respuesta correcta. \\[" +
                "%n - \\dfrac{1}{2}" + "\\]",
                OptionA = "\\(\\dfrac{|(2*%n)-1|}{2}\\)",
                OptionACorrect = true,
                OptionAFeedback = "Correcto",
                OptionB = "\\(\\dfrac{|%n-1|}{2}\\)",
                OptionBCorrect = false,
                OptionBFeedback = "Suma numeradores y deja el mismo denominador.",
                OptionC = "\\(-\\dfrac{%n}{2}\\)",
                OptionCCorrect = false,
                OptionCFeedback = "Multiplica en vez de sumar.",
                OptionD = "\\(\\dfrac{|%n+1|}{2}\\)",
                OptionDCorrect = false,
                OptionDFeedback = "Suma numeradores y deja denominador."
            });
            variables.Add(new Variable { QuestionID = 10, Symbol = "n" });
            ranges.Add(new Range { QuestionId = 10, Symbol = "n", ID = 12, Minimum = 1, Maximum = 10 });

            questions.Add(new Question
            {
                ID = 11,
                ExamID = 1,
                Description = "Realiza la operación y escoge la opción con la respuesta. \\[" +
                "\\left(\\dfrac{3}{\\sqrt{%n}}\\right)^2" + "\\]",
                OptionA = "\\(\\dfrac{9}{%n}\\)",
                OptionACorrect = true,
                OptionAFeedback = "Correcto",
                OptionB = "\\(\\dfrac{6}{%n}\\)",
                OptionBCorrect = false,
                OptionBFeedback = "Confunde elvar al cuadrado con multiplicar por 2.",
                OptionC = "\\(\\dfrac{3}{%n}\\)",
                OptionCCorrect = false,
                OptionCFeedback = "Olvidó elevar al cuadrado el numerador.",
                OptionD = "\\(\\left(\\dfrac{3\\sqrt{%n}}{%n}\\right)^2\\)",
                OptionDCorrect = false,
                OptionDFeedback = "Reacción de \"racionalizar\"."
            });
            variables.Add(new Variable { QuestionID = 11, Symbol = "n" });
            ranges.Add(new Range { QuestionId = 11, Symbol = "n", ID = 13, Minimum = 2, Maximum = 2 });
            ranges.Add(new Range { QuestionId = 11, Symbol = "n", ID = 14, Minimum = 5, Maximum = 5 });
            ranges.Add(new Range { QuestionId = 11, Symbol = "n", ID = 15, Minimum = 7, Maximum = 8 });
            ranges.Add(new Range { QuestionId = 11, Symbol = "n", ID = 16, Minimum = 10, Maximum = 11 });
            ranges.Add(new Range { QuestionId = 11, Symbol = "n", ID = 17, Minimum = 13, Maximum = 14 });

            questions.Add(new Question
            {
                ID = 12,
                ExamID = 1,
                Description = "Realiza la operación y elige la respuesta. \\[" +
                "\\dfrac{%n}{|2*%n|} + \\dfrac{|2*%n|}{%n}" + "\\]",
                OptionA = "\\(\\dfrac{5}{2}\\)",
                OptionACorrect = true,
                OptionAFeedback = "Correcto",
                OptionB = "\\(1\\)",
                OptionBCorrect = false,
                OptionBFeedback = "Suma numeradores y suma denominadores o bien cancela como si fuera producto.",
                OptionC = "\\(\\dfrac{3}{2}\\)",
                OptionCCorrect = false,
                OptionCFeedback = "Suma numeradores y deja el común denominador",
                OptionD = "\\(\\dfrac{1}{4}\\)",
                OptionDCorrect = false,
                OptionDFeedback = "Operación cruzada como división."
            });
            variables.Add(new Variable { QuestionID = 12, Symbol = "n" });
            ranges.Add(new Range { QuestionId = 12, Symbol = "n", ID = 18, Minimum = 2, Maximum = 9 });

            questions.Add(new Question
            {
                ID = 13,
                ExamID = 1,
                Description = "Realiza la operación indicada y escoge el resultado. \\[" +
                "\\dfrac{1}{3} + %n" + "\\]",
                OptionA = "\\(\\dfrac{|(3*%n)+1|}{3}\\)",
                OptionACorrect = true,
                OptionAFeedback = "Correcto",
                OptionB = "\\(\\dfrac{%n}{3}\\)",
                OptionBCorrect = false,
                OptionBFeedback = "Multiplica en vez de sumar",
                OptionC = "\\(\\dfrac{|%n+1|}{3}\\)",
                OptionCCorrect = false,
                OptionCFeedback = "Suma numeradores y deja el mismo denominador.",
                OptionD = "\\(\\dfrac{|%n+3|}{3}\\)",
                OptionDCorrect = false,
                OptionDFeedback = "Suma numerador con denominador (cruzado) y deja el mismo denominador."
            });
            variables.Add(new Variable { QuestionID = 13, Symbol = "n" });
            ranges.Add(new Range { QuestionId = 13, Symbol = "n", ID = 19, Minimum = 2, Maximum = 8 });

            questions.Add(new Question
            {
                ID = 14,
                ExamID = 1,
                Description = "Realiza la operación y escoge la respuesta. \\[" +
                "2-\\dfrac{1}{%n}" + "\\]",
                OptionA = "\\(\\dfrac{|(2*%n)-1|}{%n}\\)",
                OptionACorrect = true,
                OptionAFeedback = "Correcto",
                OptionB = "\\(\\dfrac{-2\\,\\,\\,\\,}{%n}\\)",
                OptionBCorrect = false,
                OptionBFeedback = "Multiplica en vez de sumar",
                OptionC = "\\(\\dfrac{1}{%n}\\)",
                OptionCCorrect = false,
                OptionCFeedback = "Resta numeradores y deja el mismo denominador.",
                OptionD = "\\(\\dfrac{|(2*%n)+1|}{%n}\\)",
                OptionDCorrect = false,
                OptionDFeedback = "Suma en vez de restar."
            });
            variables.Add(new Variable { QuestionID = 14, Symbol = "n" });
            ranges.Add(new Range { QuestionId = 14, Symbol = "n", ID = 20, Minimum = 2, Maximum = 9 });

            questions.Add(new Question
            {
                ID = 15,
                ExamID = 1,
                Description = "Realiza la operación y elige la respuesta correcta. \\[" +
                "\\dfrac{\\,\\,\\,\\,%n\\,\\,\\,\\,}{\\dfrac{1}{%n}}" + "\\]",
                OptionA = "\\(|%n*%n|\\)",
                OptionACorrect = true,
                OptionAFeedback = "Correcto",
                OptionB = "\\(\\dfrac{1}{|%n*%n|}\\)",
                OptionBCorrect = false,
                OptionBFeedback = "Colocación producto de extremos y medios",
                OptionC = "\\(1\\)",
                OptionCCorrect = false,
                OptionCFeedback = "Cancelación como su fuera producto y no división.",
                OptionD = "\\(|2*%n|\\)",
                OptionDCorrect = false,
                OptionDFeedback = "Confusión de elevar al cuadrado con multiplicar por 2."
            });
            variables.Add(new Variable { QuestionID = 15, Symbol = "n" });
            ranges.Add(new Range { QuestionId = 15, Symbol = "n", ID = 21, Minimum = 3, Maximum = 9 });

            questions.Add(new Question
            {
                ID = 16,
                ExamID = 1,
                Description = "Realiza la operación y elige la respuesta correcta. \\[" +
                "\\dfrac{\\,\\,\\,\\,\\dfrac{1}{%n}\\,\\,\\,\\,}{\\dfrac{1}{|%n+1|}}" + "\\]",
                OptionA = "\\(\\dfrac{|%n+1|}{%n}\\)",
                OptionACorrect = true,
                OptionAFeedback = "Correcto",
                OptionB = "\\(\\dfrac{|%n|}{|%n+1|}\\)",
                OptionBCorrect = false,
                OptionBFeedback = "Colocación de producto de extremos y medios o bien cancelar el 1.",
                OptionC = "\\(\\dfrac{1}{|(%n*%n)+%n|}\\)",
                OptionCCorrect = false,
                OptionCFeedback = "Operación como producto.",
                OptionD = "\\(\\dfrac{|(%n*%n)+%n|}{1}\\)",
                OptionDCorrect = false,
                OptionDFeedback = "Operación como producto y c9olocación en posición contraria."
            });
            variables.Add(new Variable { QuestionID = 16, Symbol = "n" });
            ranges.Add(new Range { QuestionId = 16, Symbol = "n", ID = 22, Minimum = 2, Maximum = 8 });

            questions.Add(new Question
            {
                ID = 17,
                ExamID = 1,
                Description = "Realiza la operación y escoge la respuesta. \\[" +
                "\\left(\\dfrac{%n}{3}\\right)\\left(\\dfrac{1}{|2*%n|}\\right)" + "\\]",
                OptionA = "\\(\\dfrac{1}{6}\\)",
                OptionACorrect = true,
                OptionAFeedback = "Correcto",
                OptionB = "\\(\\dfrac{1}{5}\\)",
                OptionBCorrect = false,
                OptionBFeedback = "Sumar denominadores en vez de multiplicar.",
                OptionC = "\\(\\dfrac{|2*%n*%n|}{3}\\)",
                OptionCCorrect = false,
                OptionCFeedback = "Multiplica cruzado, como división.",
                OptionD = "\\(\\dfrac{|%n+1|}{|3+(2*%n)|}\\)",
                OptionDCorrect = false,
                OptionDFeedback = "Suma numeradores y denominadores."
            });
            variables.Add(new Variable { QuestionID = 17, Symbol = "n" });
            ranges.Add(new Range { QuestionId = 17, Symbol = "n", ID = 23, Minimum = 2, Maximum = 5 });
            ranges.Add(new Range { QuestionId = 17, Symbol = "n", ID = 24, Minimum = 7, Maximum = 8 });
            ranges.Add(new Range { QuestionId = 17, Symbol = "n", ID = 25, Minimum = 10, Maximum = 10 });

            questions.Add(new Question
            {
                ID = 18,
                ExamID = 1,
                Description = "Realiza la operación indicada y elige la respuesta correcta. \\[" +
                "\\dfrac{\\,\\,\\,\\,\\dfrac{%n}{|%n+1|}\\,\\,\\,\\,}{2}" + "\\]",
                OptionA = "\\(\\dfrac{%n}{|(2*%n)+2|}\\)",
                OptionACorrect = true,
                OptionAFeedback = "Correcto",
                OptionB = "\\(\\dfrac{|2*%n|}{|%n+1|}\\)",
                OptionBCorrect = false,
                OptionBFeedback = "Confusión de extremos y medios.",
                OptionC = "\\(\\dfrac{|(2*%n)+2|}{%n}\\)",
                OptionCCorrect = false,
                OptionCFeedback = "Colocación de producto extremos y medios.",
                OptionD = "\\(\\dfrac{%n}{|%n+3|}\\)",
                OptionDCorrect = false,
                OptionDFeedback = "Al multiplicar realiza suma."
            });
            variables.Add(new Variable { QuestionID = 18, Symbol = "n" });
            ranges.Add(new Range { QuestionId = 18, Symbol = "n", ID = 26, Minimum = 3, Maximum = 3 });
            ranges.Add(new Range { QuestionId = 18, Symbol = "n", ID = 27, Minimum = 5, Maximum = 5 });
            ranges.Add(new Range { QuestionId = 18, Symbol = "n", ID = 61, Minimum = 7, Maximum = 7 });
            ranges.Add(new Range { QuestionId = 18, Symbol = "n", ID = 62, Minimum = 9, Maximum = 9 });

            questions.Add(new Question
            {
                ID = 19,
                ExamID = 1,
                Description = "Realiza la operación y elige la respuesta correcta. \\[" +
                "\\dfrac{1}{2}\\left(|(2*%n)+1|\\right)" + "\\]",
                OptionA = "\\(\\dfrac{|(2*%n)+1|}{2}\\)",
                OptionACorrect = true,
                OptionAFeedback = "Correcto",
                OptionB = "\\(\\dfrac{|(2*%n)+2|}{2}\\)",
                OptionBCorrect = false,
                OptionBFeedback = "Suma numeradores.",
                OptionC = "\\(\\dfrac{1}{|(4*%n)+2|}\\)",
                OptionCCorrect = false,
                OptionCFeedback = "Multiplica con efecto cruzado.",
                OptionD = "\\(\\dfrac{|(2*%n)+2|}{3}\\)",
                OptionDCorrect = false,
                OptionDFeedback = "Suma numeradores y denominadores."
            });
            variables.Add(new Variable { QuestionID = 19, Symbol = "n" });
            ranges.Add(new Range { QuestionId = 19, Symbol = "n", ID = 28, Minimum = 1, Maximum = 10 });

            questions.Add(new Question
            {
                ID = 20,
                ExamID = 1,
                Description = "Realiza la operación y elige la respuesta correcta. \\[" +
                "\\left(\\sqrt{%n}\\right)^3" + "\\]",
                OptionA = "\\(%n\\sqrt{%n}\\)",
                OptionACorrect = true,
                OptionAFeedback = "Correcto",
                OptionB = "\\(\\left(|%n*%n|\\right)\\left(%n\\right)\\)",
                OptionBCorrect = false,
                OptionBFeedback = "Olvido de radical.",
                OptionC = "\\(3\\sqrt{%n}\\)",
                OptionCCorrect = false,
                OptionCFeedback = "Confusión de exponente con producto.",
                OptionD = "\\(|%n*%n|\\)",
                OptionDCorrect = false,
                OptionDFeedback = "Opera al cuadrado y no al cubo."
            });
            variables.Add(new Variable { QuestionID = 20, Symbol = "n" });
            ranges.Add(new Range { QuestionId = 20, Symbol = "n", ID = 29, Minimum = 2, Maximum = 2 });
            ranges.Add(new Range { QuestionId = 20, Symbol = "n", ID = 30, Minimum = 5, Maximum = 7 });
            ranges.Add(new Range { QuestionId = 20, Symbol = "n", ID = 31, Minimum = 10, Maximum = 11 });

            questions.Add(new Question
            {
                ID = 21,
                ExamID = 1,
                Description = "Realiza la operación y escoge su respuesta. \\[" +
                "\\dfrac{1}{%n} - %n" + "\\]",
                OptionA = "\\(\\dfrac{|1-(%n*%n)|}{%n}\\)",
                OptionACorrect = true,
                OptionAFeedback = "Correcto",
                OptionB = "\\(\\dfrac{|1-%n|}{%n}\\)",
                OptionBCorrect = false,
                OptionBFeedback = "Resta de numeradores",
                OptionC = "\\(\\dfrac{|1-(2*%n)|}{%n}\\)",
                OptionCCorrect = false,
                OptionCFeedback = "Confusión elevar al cuadrado con multiplicar por 2.",
                OptionD = "\\(-\\dfrac{|%n*%n|}{%n}\\)",
                OptionDCorrect = false,
                OptionDFeedback = "Operación cruzada."
            });
            variables.Add(new Variable { QuestionID = 21, Symbol = "n" });
            ranges.Add(new Range { QuestionId = 21, Symbol = "n", ID = 32, Minimum = 2, Maximum = 9 });

            questions.Add(new Question
            {
                ID = 22,
                ExamID = 1,
                Description = "Realiza la operación y elige su respuesta. \\[" +
                "%n-\\dfrac{1}{%m}" + "\\]",
                OptionA = "\\(\\dfrac{|(%n*%m) - 1|}{%m}\\)",
                OptionACorrect = true,
                OptionAFeedback = "Correcto",
                OptionB = "\\(\\dfrac{|%n-1|}{%m}\\)",
                OptionBCorrect = false,
                OptionBFeedback = "Resta de numeradores",
                OptionC = "\\(\\dfrac{|(%n*%m)|}{%m}\\)",
                OptionCCorrect = false,
                OptionCFeedback = "Olvido de resta de 1",
                OptionD = "\\(-\\dfrac{%n}{%m}\\)",
                OptionDCorrect = false,
                OptionDFeedback = "Confusión con multiplicación."
            });
            variables.Add(new Variable { QuestionID = 22, Symbol = "n" });
            ranges.Add(new Range { QuestionId = 22, Symbol = "n", ID = 33, Minimum = 2, Maximum = 2 });
            ranges.Add(new Range { QuestionId = 22, Symbol = "n", ID = 34, Minimum = 4, Maximum = 4 });
            ranges.Add(new Range { QuestionId = 22, Symbol = "n", ID = 35, Minimum = 6, Maximum = 6 });
            ranges.Add(new Range { QuestionId = 22, Symbol = "n", ID = 36, Minimum = 8, Maximum = 8 });
            ranges.Add(new Range { QuestionId = 22, Symbol = "n", ID = 37, Minimum = 10, Maximum = 10 });
            variables.Add(new Variable { QuestionID = 22, Symbol = "m" });
            ranges.Add(new Range { QuestionId = 22, Symbol = "m", ID = 38, Minimum = 3, Maximum = 3 });
            ranges.Add(new Range { QuestionId = 22, Symbol = "m", ID = 39, Minimum = 5, Maximum = 5 });
            ranges.Add(new Range { QuestionId = 22, Symbol = "m", ID = 40, Minimum = 7, Maximum = 7 });
            ranges.Add(new Range { QuestionId = 22, Symbol = "m", ID = 41, Minimum = 9, Maximum = 9 });

            questions.Add(new Question
            {
                ID = 23,
                ExamID = 1,
                Description = "Realiza la operación y escoge su respuesta. \\[" +
                "\\dfrac{1}{%n}-\\dfrac{%n}{%m}" + "\\]",
                OptionA = "\\(\\dfrac{|%m-(%n*%n)|}{|%m*%n|}\\)",
                OptionACorrect = true,
                OptionAFeedback = "Correcto",
                OptionB = "\\(-\\dfrac{1}{%m}\\)",
                OptionBCorrect = false,
                OptionBFeedback = "Confusión con multiplicación.",
                OptionC = "\\(\\dfrac{|1-%n|}{|%n-%m|}\\)",
                OptionCCorrect = false,
                OptionCFeedback = "Resta de numeradores y denominadores.",
                OptionD = "\\(\\dfrac{|1-%n|}{|%n*%m|}\\)",
                OptionDCorrect = false,
                OptionDFeedback = "Resta numeradores y común denominador."
            });
            variables.Add(new Variable { QuestionID = 23, Symbol = "n" });
            ranges.Add(new Range { QuestionId = 23, Symbol = "n", ID = 42, Minimum = 2, Maximum = 2 });
            ranges.Add(new Range { QuestionId = 23, Symbol = "n", ID = 43, Minimum = 4, Maximum = 4 });
            ranges.Add(new Range { QuestionId = 23, Symbol = "n", ID = 44, Minimum = 6, Maximum = 6 });
            ranges.Add(new Range { QuestionId = 23, Symbol = "n", ID = 45, Minimum = 8, Maximum = 8 });
            ranges.Add(new Range { QuestionId = 23, Symbol = "n", ID = 46, Minimum = 10, Maximum = 10 });
            variables.Add(new Variable { QuestionID = 23, Symbol = "m" });
            ranges.Add(new Range { QuestionId = 23, Symbol = "m", ID = 47, Minimum = 1, Maximum = 1 });
            ranges.Add(new Range { QuestionId = 23, Symbol = "m", ID = 48, Minimum = 3, Maximum = 3 });
            ranges.Add(new Range { QuestionId = 23, Symbol = "m", ID = 49, Minimum = 5, Maximum = 5 });
            ranges.Add(new Range { QuestionId = 23, Symbol = "m", ID = 50, Minimum = 7, Maximum = 7 });
            ranges.Add(new Range { QuestionId = 23, Symbol = "m", ID = 51, Minimum = 9, Maximum = 9 });

            questions.Add(new Question
            {
                ID = 24,
                ExamID = 1,
                Description = "Realiza la operación y elige la respuesta correspondiente. \\[" +
                "\\dfrac{%m}{\\,\\,\\,\\,\\dfrac{1}{%n}\\,\\,\\,\\,}" + "\\]",
                OptionA = "\\(|%m*%n|\\)",
                OptionACorrect = true,
                OptionAFeedback = "Correcto",
                OptionB = "\\(\\dfrac{%m}{%n}\\)",
                OptionBCorrect = false,
                OptionBFeedback = "Confusión extremos y medios.",
                OptionC = "\\(\\dfrac{%n}{%m}\\)",
                OptionCCorrect = false,
                OptionCFeedback = "Confusión extremos y medios.",
                OptionD = "\\(\\dfrac{1}{|%n*%m|}\\)",
                OptionDCorrect = false,
                OptionDFeedback = "Confusión extremos y medios."
            });
            variables.Add(new Variable { QuestionID = 24, Symbol = "n" });
            ranges.Add(new Range { QuestionId = 24, Symbol = "n", ID = 52, Minimum = 2, Maximum = 2 });
            ranges.Add(new Range { QuestionId = 24, Symbol = "n", ID = 53, Minimum = 4, Maximum = 4 });
            ranges.Add(new Range { QuestionId = 24, Symbol = "n", ID = 54, Minimum = 6, Maximum = 6 });
            ranges.Add(new Range { QuestionId = 24, Symbol = "n", ID = 55, Minimum = 8, Maximum = 8 });
            ranges.Add(new Range { QuestionId = 24, Symbol = "n", ID = 56, Minimum = 10, Maximum = 10 });
            variables.Add(new Variable { QuestionID = 24, Symbol = "m" });
            ranges.Add(new Range { QuestionId = 24, Symbol = "m", ID = 57, Minimum = 1, Maximum = 1 });
            ranges.Add(new Range { QuestionId = 24, Symbol = "m", ID = 58, Minimum = 3, Maximum = 3 });
            ranges.Add(new Range { QuestionId = 24, Symbol = "m", ID = 59, Minimum = 5, Maximum = 5 });
            ranges.Add(new Range { QuestionId = 24, Symbol = "m", ID = 60, Minimum = 7, Maximum = 7 });
            ranges.Add(new Range { QuestionId = 24, Symbol = "m", ID = 61, Minimum = 9, Maximum = 9 });

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