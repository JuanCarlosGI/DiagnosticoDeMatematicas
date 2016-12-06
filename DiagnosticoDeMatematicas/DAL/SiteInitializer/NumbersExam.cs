namespace DiagnosticoDeMatematicas.DAL
{
    using Models;

    public partial class SiteInitializer
    {
        private void NumbersExam()
        {
            _exams.Add(new Exam
            {
                Id = ++_examCounter,
                Name = "Números",
                Description = 
                "Los números son símbolos.\n" +
                "Representan una cantidad de cosas o bien la medida de algo.\n" +
                "Con los números podemos realizar operaciones aritméticas que nos concretan acciones que podemos hacer con lo que representan.\n",
                Active = true
            });

            _questions.Add(new SingleSelectionQuestion
            {
                Id = ++_questionCounter,
                ExamId = _examCounter,
                Description = "Realiza la siguiente operación aritmétca y elige la opción con la respuesta.\\[" +
                "%n+\\frac{|%n-1|}{%n}" + "\\]"
            });
            _options.Add(new QuestionOption {Description = "\\(\\dfrac{|%n*%n+%n-1|}{%n}\\)", IsCorrect = true, Feedback = "Correcto", Id = ++_optionCounter, QuestionId = _questionCounter});
            _options.Add(new QuestionOption { Description = "\\(\\dfrac{|2*%n-1|}{%n}\\)", IsCorrect = false, Feedback = "Suma numeradores y deja el mismo denominador.", Id = ++_optionCounter, QuestionId = _questionCounter});
            _options.Add(new QuestionOption { Description = "\\(\\dfrac{|%n-1|}{1}\\)", IsCorrect = false, Feedback = "Cancela numerador con denominador.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(\\dfrac{|2*%n-1|}{|%n+1|}\\)", IsCorrect = false, Feedback = "Suma numeradores y suma denominadores.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _variables.Add(new Variable { QuestionId = _questionCounter, Symbol = "n" });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 3, Maximum = 12 });

            _questions.Add(new SingleSelectionQuestion
            {
                Id = ++_questionCounter,
                ExamId = _examCounter,
                Description = "Realiza la operación aritmética y elige la opción que muestra el resultado. \\[" +
                "\\dfrac{1}{%n} - \\dfrac{%n}{|%n+1|}" + "\\]"
            });
            _options.Add(new QuestionOption { Description = "\\(\\dfrac{|1+%n-%n*%n|}{|%n*%n+%n|}\\)", IsCorrect = true, Feedback = "Correcto", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(\\dfrac{|1-%n|}{|%n*%n+%n|}\\)", IsCorrect = false, Feedback = "Resta numeradores y multiplica denominadores.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(-\\dfrac{1}{|%n+1|}\\)", IsCorrect = false, Feedback = "Cancela numerador con denominador (como un producto).", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(\\dfrac{|1-%n|}{|2*%n+1|}\\)", IsCorrect = false, Feedback = "Resta numeradores y suma denominadores", Id = ++_optionCounter, QuestionId = _questionCounter });
            _variables.Add(new Variable { QuestionId = _questionCounter, Symbol = "n" });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 3, Maximum = 12 });

            _questions.Add(new SingleSelectionQuestion
            {
                Id = ++_questionCounter,
                ExamId = _examCounter,
                Description = "Realiza la operación aritmética indicada y escoge la opción con su resultado. \\[" +
                "\\left ( \\dfrac{1}{%n} \\right )\\left ( \\dfrac{|3*%n|}{13} \\right )" + "\\]"
            });
            _options.Add(new QuestionOption { Description = "\\(\\dfrac{3}{13}\\)", IsCorrect = true, Feedback = "Correcto", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(\\dfrac{|3*%n+1|}{|%n+13|}\\)", IsCorrect = false, Feedback = "Suma numeradores y suma denominadores", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(\\dfrac{13}{|3*%n*%n|}\\)", IsCorrect = false, Feedback = "Cruza productos como si fuese división.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(\\dfrac{|3*%n+1|}{|13*%n|}\\)", IsCorrect = false, Feedback = "Suma numeradores y multiplica denominadores.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _variables.Add(new Variable { QuestionId = _questionCounter, Symbol = "n" });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 2, Maximum = 11 });

            _questions.Add(new SingleSelectionQuestion
            {
                Id = ++_questionCounter,
                ExamId = _examCounter,
                Description = "Realiza la operación señalada y elige la opción que meustra el resultado correcto. \\[" +
                "\\left ( %n \\sqrt{%n} \\right )^{2}" + "\\]"
            });
            _options.Add(new QuestionOption { Description = "\\(|%n*%n*%n|\\)", IsCorrect = true, Feedback = "Correcto", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(|%n*%n|\\)", IsCorrect = false, Feedback = "Olvida elevar al cuadrado al valor libre", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(|%n*%n|\\sqrt{%n}\\)", IsCorrect = false, Feedback = "Olvida elevar al cuadrado el radical.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(\\sqrt{|%n*%n*%n|}\\)", IsCorrect = false, Feedback = "Realiza operación dentro del radical.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _variables.Add(new Variable { QuestionId = _questionCounter, Symbol = "n" });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 2, Maximum = 3 });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 5, Maximum = 8 });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 10, Maximum = 10 });

            _questions.Add(new SingleSelectionQuestion
            {
                Id = ++_questionCounter,
                ExamId = _examCounter,
                Description = "Realiza la operación y selecciona su resultado. \\[" +
                "1 + \\dfrac{1}{%n}" + "\\]"
            });
            _options.Add(new QuestionOption { Description = "\\(\\dfrac{|%n+1|}{%n}\\)", IsCorrect = true, Feedback = "Correcto", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(\\dfrac{2}{%n}\\)", IsCorrect = false, Feedback = "Suma numeradores y deja el mismo denominador.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(\\dfrac{2}{|1+%n|}\\)", IsCorrect = false, Feedback = "Suma numeradores y suma denominadores.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(\\dfrac{%n}{|%n+1|}\\)", IsCorrect = false, Feedback = "Confunde posición de numerador y denominador.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _variables.Add(new Variable { QuestionId = _questionCounter, Symbol = "n" });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 3, Maximum = 10 });

            _questions.Add(new SingleSelectionQuestion
            {
                Id = ++_questionCounter,
                ExamId = _examCounter,
                Description = "Realiza la operación indicada y selecciona la respuesta correcta. \\[" +
                "%n - \\dfrac{1}{2}" + "\\]"
            });
            _options.Add(new QuestionOption { Description = "\\(\\dfrac{|(2*%n)-1|}{2}\\)", IsCorrect = true, Feedback = "Correcto", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(\\dfrac{|%n-1|}{2}\\)", IsCorrect = false, Feedback = "Suma numeradores y deja el mismo denominador.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(-\\dfrac{%n}{2}\\)", IsCorrect = false, Feedback = "Multiplica en vez de sumar.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(\\dfrac{|%n+1|}{2}\\)", IsCorrect = false, Feedback = "Suma numeradores y deja denominador.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _variables.Add(new Variable { QuestionId = _questionCounter, Symbol = "n" });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 1, Maximum = 10 });

            _questions.Add(new SingleSelectionQuestion
            {
                Id = ++_questionCounter,
                ExamId = _examCounter,
                Description = "Realiza la operación y escoge la opción con la respuesta. \\[" +
                "\\left(\\dfrac{3}{\\sqrt{%n}}\\right)^2" + "\\]"
            });
            _options.Add(new QuestionOption { Description = "\\(\\dfrac{9}{%n}\\)", IsCorrect = true, Feedback = "Correcto", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(\\dfrac{6}{%n}\\)", IsCorrect = false, Feedback = "Confunde elvar al cuadrado con multiplicar por 2.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(\\dfrac{3}{%n}\\)", IsCorrect = false, Feedback = "Olvidó elevar al cuadrado el numerador.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(\\left(\\dfrac{3\\sqrt{%n}}{%n}\\right)^2\\)", IsCorrect = false, Feedback = "Reacción de \"racionalizar\".", Id = ++_optionCounter, QuestionId = _questionCounter });
            _variables.Add(new Variable { QuestionId = _questionCounter, Symbol = "n" });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 2, Maximum = 2 });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 5, Maximum = 5 });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 7, Maximum = 8 });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 10, Maximum = 11 });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 13, Maximum = 14 });

            _questions.Add(new SingleSelectionQuestion
            {
                Id = ++_questionCounter,
                ExamId = _examCounter,
                Description = "Realiza la operación y elige la respuesta. \\[" +
                "\\dfrac{%n}{|2*%n|} + \\dfrac{|2*%n|}{%n}" + "\\]"
            });
            _options.Add(new QuestionOption { Description = "\\(\\dfrac{5}{2}\\)", IsCorrect = true, Feedback = "Correcto", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(1\\)", IsCorrect = false, Feedback = "Suma numeradores y suma denominadores o bien cancela como si fuera producto.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(\\dfrac{3}{2}\\)", IsCorrect = false, Feedback = "Suma numeradores y deja el común denominador", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(\\dfrac{1}{4}\\)", IsCorrect = false, Feedback = "Operación cruzada como división.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _variables.Add(new Variable { QuestionId = _questionCounter, Symbol = "n" });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 2, Maximum = 9 });

            _questions.Add(new SingleSelectionQuestion
            {
                Id = ++_questionCounter,
                ExamId = _examCounter,
                Description = "Realiza la operación indicada y escoge el resultado. \\[" +
                "\\dfrac{1}{3} + %n" + "\\]"
            });
            _options.Add(new QuestionOption { Description = "\\(\\dfrac{|(3*%n)+1|}{3}\\)", IsCorrect = true, Feedback = "Correcto", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(\\dfrac{%n}{3}\\)", IsCorrect = false, Feedback = "Multiplica en vez de sumar", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(\\dfrac{|%n+1|}{3}\\)", IsCorrect = false, Feedback = "Suma numeradores y deja el mismo denominador.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(\\dfrac{|%n+3|}{3}\\)", IsCorrect = false, Feedback = "Suma numerador con denominador (cruzado) y deja el mismo denominador.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _variables.Add(new Variable { QuestionId = _questionCounter, Symbol = "n" });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 2, Maximum = 8 });

            _questions.Add(new SingleSelectionQuestion
            {
                Id = ++_questionCounter,
                ExamId = _examCounter,
                Description = "Realiza la operación y escoge la respuesta. \\[" +
                "2-\\dfrac{1}{%n}" + "\\]"
            });
            _options.Add(new QuestionOption { Description = "\\(\\dfrac{|(2*%n)-1|}{%n}\\)", IsCorrect = true, Feedback = "Correcto", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(\\dfrac{-2\\,\\,\\,\\,}{%n}\\)", IsCorrect = false, Feedback = "Multiplica en vez de sumar", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(\\dfrac{1}{%n}\\)", IsCorrect = false, Feedback = "Resta numeradores y deja el mismo denominador.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(\\dfrac{|(2*%n)+1|}{%n}\\)", IsCorrect = false, Feedback = "Suma en vez de restar.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _variables.Add(new Variable { QuestionId = _questionCounter, Symbol = "n" });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 2, Maximum = 9 });

            _questions.Add(new SingleSelectionQuestion
            {
                Id = ++_questionCounter,
                ExamId = _examCounter,
                Description = "Realiza la operación y elige la respuesta correcta. \\[" +
                "\\dfrac{\\,\\,\\,\\,%n\\,\\,\\,\\,}{\\dfrac{1}{%n}}" + "\\]"
            });
            _options.Add(new QuestionOption { Description = "\\(|%n*%n|\\)", IsCorrect = true, Feedback = "Correcto", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(\\dfrac{1}{|%n*%n|}\\)", IsCorrect = false, Feedback = "Colocación producto de extremos y medios", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(1\\)", IsCorrect = false, Feedback = "Cancelación como su fuera producto y no división.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(|2*%n|\\)", IsCorrect = false, Feedback = "Confusión de elevar al cuadrado con multiplicar por 2.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _variables.Add(new Variable { QuestionId = _questionCounter, Symbol = "n" });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 3, Maximum = 9 });

            _questions.Add(new SingleSelectionQuestion
            {
                Id = ++_questionCounter,
                ExamId = _examCounter,
                Description = "Realiza la operación y elige la respuesta correcta. \\[" +
                "\\dfrac{\\,\\,\\,\\,\\dfrac{1}{%n}\\,\\,\\,\\,}{\\dfrac{1}{|%n+1|}}" + "\\]"
            });
            _options.Add(new QuestionOption { Description = "\\(\\dfrac{|%n+1|}{%n}\\)", IsCorrect = true, Feedback = "Correcto", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(\\dfrac{|%n|}{|%n+1|}\\)", IsCorrect = false, Feedback = "Colocación de producto de extremos y medios o bien cancelar el 1.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(\\dfrac{1}{|(%n*%n)+%n|}\\)", IsCorrect = false, Feedback = "Operación como producto.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(\\dfrac{|(%n*%n)+%n|}{1}\\)", IsCorrect = false, Feedback = "Operación como producto y c9olocación en posición contraria.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _variables.Add(new Variable { QuestionId = _questionCounter, Symbol = "n" });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 2, Maximum = 8 });

            _questions.Add(new SingleSelectionQuestion
            {
                Id = ++_questionCounter,
                ExamId = _examCounter,
                Description = "Realiza la operación y escoge la respuesta. \\[" +
                "\\left(\\dfrac{%n}{3}\\right)\\left(\\dfrac{1}{|2*%n|}\\right)" + "\\]"
            });
            _options.Add(new QuestionOption { Description = "\\(\\dfrac{1}{6}\\)", IsCorrect = true, Feedback = "Correcto", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(\\dfrac{1}{5}\\)", IsCorrect = false, Feedback = "Sumar denominadores en vez de multiplicar.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(\\dfrac{|2*%n*%n|}{3}\\)", IsCorrect = false, Feedback = "Multiplica cruzado, como división.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(\\dfrac{|%n+1|}{|3+(2*%n)|}\\)", IsCorrect = false, Feedback = "Suma numeradores y denominadores.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _variables.Add(new Variable { QuestionId = _questionCounter, Symbol = "n" });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 2, Maximum = 5 });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 7, Maximum = 8 });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 10, Maximum = 10 });

            _questions.Add(new SingleSelectionQuestion
            {
                Id = ++_questionCounter,
                ExamId = _examCounter,
                Description = "Realiza la operación indicada y elige la respuesta correcta. \\[" +
                "\\dfrac{\\,\\,\\,\\,\\dfrac{%n}{|%n+1|}\\,\\,\\,\\,}{2}" + "\\]"
            });
            _options.Add(new QuestionOption { Description = "\\(\\dfrac{%n}{|(2*%n)+2|}\\)", IsCorrect = true, Feedback = "Correcto", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(\\dfrac{|2*%n|}{|%n+1|}\\)", IsCorrect = false, Feedback = "Confusión de extremos y medios.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(\\dfrac{|(2*%n)+2|}{%n}\\)", IsCorrect = false, Feedback = "Colocación de producto extremos y medios.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(\\dfrac{%n}{|%n+3|}\\)", IsCorrect = false, Feedback = "Al multiplicar realiza suma.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _variables.Add(new Variable { QuestionId = _questionCounter, Symbol = "n" });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 3, Maximum = 3 });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 5, Maximum = 5 });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 7, Maximum = 7 });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 9, Maximum = 9 });

            _questions.Add(new SingleSelectionQuestion
            {
                Id = ++_questionCounter,
                ExamId = _examCounter,
                Description = "Realiza la operación y elige la respuesta correcta. \\[" +
                "\\dfrac{1}{2}\\left(|(2*%n)+1|\\right)" + "\\]"
            });
            _options.Add(new QuestionOption { Description = "\\(\\dfrac{|(2*%n)+1|}{2}\\)", IsCorrect = true, Feedback = "Correcto", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(\\dfrac{|(2*%n)+2|}{2}\\)", IsCorrect = false, Feedback = "Suma numeradores.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(\\dfrac{1}{|(4*%n)+2|}\\)", IsCorrect = false, Feedback = "Multiplica con efecto cruzado.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(\\dfrac{|(2*%n)+2|}{3}\\)", IsCorrect = false, Feedback = "Suma numeradores y denominadores.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _variables.Add(new Variable { QuestionId = _questionCounter, Symbol = "n" });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 1, Maximum = 10 });

            _questions.Add(new SingleSelectionQuestion
            {
                Id = ++_questionCounter,
                ExamId = _examCounter,
                Description = "Realiza la operación y elige la respuesta correcta. \\[" +
                "\\left(\\sqrt{%n}\\right)^3" + "\\]"
            });
            _options.Add(new QuestionOption { Description = "\\(%n\\sqrt{%n}\\)", IsCorrect = true, Feedback = "Correcto", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(\\left(|%n*%n|\\right)\\left(%n\\right)\\)", IsCorrect = false, Feedback = "Olvido de radical.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(3\\sqrt{%n}\\)", IsCorrect = false, Feedback = "Confusión de exponente con producto.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(|%n*%n|\\)", IsCorrect = false, Feedback = "Opera al cuadrado y no al cubo.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _variables.Add(new Variable { QuestionId = _questionCounter, Symbol = "n" });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 2, Maximum = 2 });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 5, Maximum = 7 });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 10, Maximum = 11 });

            _questions.Add(new SingleSelectionQuestion
            {
                Id = ++_questionCounter,
                ExamId = _examCounter,
                Description = "Realiza la operación y escoge su respuesta. \\[" +
                "\\dfrac{1}{%n} - %n" + "\\]"
            });
            _options.Add(new QuestionOption { Description = "\\(\\dfrac{|1-(%n*%n)|}{%n}\\)", IsCorrect = true, Feedback = "Correcto", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(\\dfrac{|1-%n|}{%n}\\)", IsCorrect = false, Feedback = "Resta de numeradores", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(\\dfrac{|1-(2*%n)|}{%n}\\)", IsCorrect = false, Feedback = "Confusión elevar al cuadrado con multiplicar por 2.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(-\\dfrac{|%n*%n|}{%n}\\)", IsCorrect = false, Feedback = "Operación cruzada.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _variables.Add(new Variable { QuestionId = _questionCounter, Symbol = "n" });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 2, Maximum = 9 });

            _questions.Add(new SingleSelectionQuestion
            {
                Id = ++_questionCounter,
                ExamId = _examCounter,
                Description = "Realiza la operación y elige su respuesta. \\[" +
                "%n-\\dfrac{1}{%m}" + "\\]"
            });
            _options.Add(new QuestionOption { Description = "\\(\\dfrac{|(%n*%m) - 1|}{%m}\\)", IsCorrect = true, Feedback = "Correcto", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(\\dfrac{|%n-1|}{%m}\\)", IsCorrect = false, Feedback = "Resta de numeradores", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(\\dfrac{|(%n*%m)|}{%m}\\)", IsCorrect = false, Feedback = "Olvido de resta de 1", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(-\\dfrac{%n}{%m}\\)", IsCorrect = false, Feedback = "Confusión con multiplicación.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _variables.Add(new Variable { QuestionId = _questionCounter, Symbol = "n" });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 2, Maximum = 2 });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 4, Maximum = 4 });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 6, Maximum = 6 });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 8, Maximum = 8 });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 10, Maximum = 10 });
            _variables.Add(new Variable { QuestionId = _questionCounter, Symbol = "m" });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "m", Id = ++_rangeCounter, Minimum = 3, Maximum = 3 });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "m", Id = ++_rangeCounter, Minimum = 5, Maximum = 5 });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "m", Id = ++_rangeCounter, Minimum = 7, Maximum = 7 });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "m", Id = ++_rangeCounter, Minimum = 9, Maximum = 9 });

            _questions.Add(new SingleSelectionQuestion
            {
                Id = ++_questionCounter,
                ExamId = _examCounter,
                Description = "Realiza la operación y escoge su respuesta. \\[" +
                "\\dfrac{1}{%n}-\\dfrac{%n}{%m}" + "\\]"
            });
            _options.Add(new QuestionOption { Description = "\\(\\dfrac{|%m-(%n*%n)|}{|%m*%n|}\\)", IsCorrect = true, Feedback = "Correcto", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(-\\dfrac{1}{%m}\\)", IsCorrect = false, Feedback = "Confusión con multiplicación.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(\\dfrac{|1-%n|}{|%n-%m|}\\)", IsCorrect = false, Feedback = "Resta de numeradores y denominadores.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(\\dfrac{|1-%n|}{|%n*%m|}\\)", IsCorrect = false, Feedback = "Resta numeradores y común denominador.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _variables.Add(new Variable { QuestionId = _questionCounter, Symbol = "n" });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 2, Maximum = 2 });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 4, Maximum = 4 });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 6, Maximum = 6 });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 8, Maximum = 8 });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 10, Maximum = 10 });
            _variables.Add(new Variable { QuestionId = _questionCounter, Symbol = "m" });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "m", Id = ++_rangeCounter, Minimum = 1, Maximum = 1 });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "m", Id = ++_rangeCounter, Minimum = 3, Maximum = 3 });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "m", Id = ++_rangeCounter, Minimum = 5, Maximum = 5 });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "m", Id = ++_rangeCounter, Minimum = 7, Maximum = 7 });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "m", Id = ++_rangeCounter, Minimum = 9, Maximum = 9 });

            _questions.Add(new SingleSelectionQuestion
            {
                Id = ++_questionCounter,
                ExamId = _examCounter,
                Description = "Realiza la operación y elige la respuesta correspondiente. \\[" +
                "\\dfrac{%m}{\\,\\,\\,\\,\\dfrac{1}{%n}\\,\\,\\,\\,}" + "\\]"
            });
            _options.Add(new QuestionOption { Description = "\\(|%m*%n|\\)", IsCorrect = true, Feedback = "Correcto", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(\\dfrac{%m}{%n}\\)", IsCorrect = false, Feedback = "Confusión extremos y medios.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(\\dfrac{%n}{%m}\\)", IsCorrect = false, Feedback = "Confusión extremos y medios.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(\\dfrac{1}{|%n*%m|}\\)", IsCorrect = false, Feedback = "Confusión extremos y medios.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _variables.Add(new Variable { QuestionId = _questionCounter, Symbol = "n" });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 2, Maximum = 2 });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 4, Maximum = 4 });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 6, Maximum = 6 });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 8, Maximum = 8 });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 10, Maximum = 10 });
            _variables.Add(new Variable { QuestionId = _questionCounter, Symbol = "m" });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "m", Id = ++_rangeCounter, Minimum = 1, Maximum = 1 });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "m", Id = ++_rangeCounter, Minimum = 3, Maximum = 3 });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "m", Id = ++_rangeCounter, Minimum = 5, Maximum = 5 });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "m", Id = ++_rangeCounter, Minimum = 7, Maximum = 7 });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "m", Id = ++_rangeCounter, Minimum = 9, Maximum = 9 });
        }
    }
}
