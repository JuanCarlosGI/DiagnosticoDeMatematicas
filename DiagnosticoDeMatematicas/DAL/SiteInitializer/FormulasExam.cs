using DiagnosticoDeMatematicas.Models;

namespace DiagnosticoDeMatematicas.DAL
{
    public partial class SiteInitializer
    {
        private void FormulasExam()
        {
            _exams.Add(new Exam
            {
                Id = ++_examCounter,
                Name = "F�rmulas",
                Description =
                "Las f�rmulas son maneras concretas de representar algo que cumplen los n�meros.\n" +
                "Son expresiones algebraicas donde podemos encontrar letras, n�meros y operaciones que los conectan.\n" +
                "Con las f�rmulas somos capaces de expresar comportamientos y realizar procedimientos de una manera general\n",
                Active = true
            });

            _questions.Add(new SingleSelectionQuestion
            {
                Id = ++_questionCounter,
                ExamId = _examCounter,
                Description = "Entre las opciones dadas abajo, elige la que es equivalente a la siguiente: \\[" +
                "\\left ( x^{2} + |%n*%n| \\right )^{-2}\\]"
            });
            _options.Add(new QuestionOption { Description = "\\(\\dfrac{1}{\\left ( x^{2} + |%n*%n|\\right )^{2}}\\)", IsCorrect = true, Feedback = "Correcto", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(\\dfrac{1}{x^{4} + |%n*%n|^{2}}\\)", IsCorrect = false, Feedback = "Realiza suma de los cuadrados de cada t�rmino", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(-\\left ( x^{2} + |%n*%n|\\right )^{2}\\)", IsCorrect = false, Feedback = "Interpretaci�n incorrecta de signo negativo en exponente.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(x^{-4} + |%n*%n|^{-2}\\)", IsCorrect = false, Feedback = "Distribuye el exponente en cada t�rmino.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _variables.Add(new Variable { QuestionId = _questionCounter, Symbol = "n" });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 2, Maximum = 10 });

            _questions.Add(new SingleSelectionQuestion
            {
                Id = ++_questionCounter,
                ExamId = _examCounter,
                Description = "Entre las siguiente opciones elige la que es equivalente a la expresi�n algebraica. \\[" +
                "\\sqrt{x^{2} + |%n*%n|}\\]"
            });
            _options.Add(new QuestionOption { Description = "\\(\\left (x^{2} + |%n*%n|\\right )^{1/2}\\)", IsCorrect = true, Feedback = "Correcto", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(\\sqrt{\\left (x+%n\\right )\\left (x-%n\\right )}\\)", IsCorrect = false, Feedback = "Aplica producto notable de diferencia de cuadrados en una suma de cuadrados", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(x+%n\\)", IsCorrect = false, Feedback = "Distribuye el radical en cada t�rmino y cancela el cuadrado con el radical.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(\\sqrt{\\left (x+%n\\right )^{2}}\\)", IsCorrect = false, Feedback = "Producto notable de binomio al cuadrado confundido con suma de cuadrados de cada t�rmino.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _variables.Add(new Variable { QuestionId = _questionCounter, Symbol = "n" });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 1, Maximum = 10 });

            _questions.Add(new SingleSelectionQuestion
            {
                Id = ++_questionCounter,
                ExamId = _examCounter,
                Description = "Simplifica la expresi�n dada en seguida y selecciona la opci�n que le corresponde \\[" +
                "\\left (\\dfrac{%nab^{|%n+1|}}{b^{%n}}\\right )^{-1}\\]"
            });
            _options.Add(new QuestionOption { Description = "\\(\\dfrac{1}{%nab}\\)", IsCorrect = true, Feedback = "Correcto", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(-%nab\\)", IsCorrect = false, Feedback = "Exponente negativo confundido con cambio de signo.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(\\dfrac{%nab}{1}\\)", IsCorrect = false, Feedback = "No opera el exponente negativo.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(\\dfrac{%n}{ab}\\)", IsCorrect = false, Feedback = "Opera el exponente negativo s�lo a las letras y no a los n�meros.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _variables.Add(new Variable { QuestionId = _questionCounter, Symbol = "n" });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 2, Maximum = 10 });

            _questions.Add(new SingleSelectionQuestion
            {
                Id = ++_questionCounter,
                ExamId = _examCounter,
                Description = "Simplifica la expresi�n con radicales dada enseguida y elcoge la opci�n que la muestra. \\[" +
                "\\sqrt{x^{|2*%n|}y^{|19-2*%n|}}\\]"
            });
            _options.Add(new QuestionOption { Description = "\\(x^{%n}y^{|9-%n|}\\sqrt{y}\\)", IsCorrect = true, Feedback = "Correcto", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(x^{|2*%n|}y^{|18-2*%n|}\\sqrt{y}\\)", IsCorrect = false, Feedback = "No divide entre 2 el exponente ni de 'x' ni de 'y' al extraer del radical.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(x^{%n}y^{|18-2*%n|}\\sqrt{y}\\)", IsCorrect = false, Feedback = "No divide entre 2 el exponente de 'y' al extraer del radical.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(x^{|2*%n|}y^{|9-%n|}\\sqrt{y}\\)", IsCorrect = false, Feedback = "No divide entre 2 el exponente de 'x' al extraer del radical.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _variables.Add(new Variable { QuestionId = _questionCounter, Symbol = "n" });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 2, Maximum = 7 });

            _questions.Add(new SingleSelectionQuestion
            {
                Id = ++_questionCounter,
                ExamId = _examCounter,
                Description = "Selecciona la expresi�n que representa el resultado de multiplicar: \\[" +
                "\\left(%ma^2+%nb^2\\right)\\left(2b^2-%na^2\\right)\\]"
            });
            _options.Add(new QuestionOption { Description = "\\(|2*%m - %n*%n|a^2b^2+|2*%n|b^4-|%m*%n|a^4\\)", IsCorrect = true, Feedback = "Correcto", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(|2*%m|a^2b^2-|%n*%n|b^2a^2\\)", IsCorrect = false, Feedback = "Opera s�lo los primeros t�rminos y los segundos t�rminos.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(|2*%m|a^2b^2+|2*%n|b^4-%na^2\\)", IsCorrect = false, Feedback = "Opera el primer binomio con el primer t�rmino del segundo binomio como si no hubiera un par�ntesis.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(|%m + 2 - %n * %n|a^2b^2 + |2*%n|b^4 - |%m*%n|a^4\\)", IsCorrect = false, Feedback = "Opera suma en vez de multiplicaci�n en el primer t�rmino.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _variables.Add(new Variable { QuestionId = _questionCounter, Symbol = "m" });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "m", Id = ++_rangeCounter, Minimum = 3, Maximum = 5 });
            _variables.Add(new Variable { QuestionId = _questionCounter, Symbol = "n" });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = -1, Maximum = -1 });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 1, Maximum = 1 });

            _questions.Add(new SingleSelectionQuestion
            {
                Id = ++_questionCounter,
                ExamId = _examCounter,
                Description = "Efectua la resta y elige la expresi�n que resulta. \\[" +
                "\\dfrac{1}{x+%m} - %n\\]"
            });
            _options.Add(new QuestionOption { Description = "\\(\\dfrac{|1 - %n * %m| - %nx}{x + %m}\\)", IsCorrect = true, Feedback = "Correcto", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(\\dfrac{|1 - %m| - %nx}{x + %m}\\)", IsCorrect = false, Feedback = "Multiplica un solo t�rmino.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(\\dfrac{|1 + %n * %m| - %nx}{x + %m}\\)", IsCorrect = false, Feedback = "Olvido signo al multiplicar el segundo t�rmino.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(\\dfrac{|1 - %n|}{x + %m}\\)", IsCorrect = false, Feedback = "Opera numeradroes sin considerar denominador.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _variables.Add(new Variable { QuestionId = _questionCounter, Symbol = "n" });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 1, Maximum = 4 });
            _variables.Add(new Variable { QuestionId = _questionCounter, Symbol = "m" });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "m", Id = ++_rangeCounter, Minimum = 1, Maximum = 4 });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "m", Id = ++_rangeCounter, Minimum = -4, Maximum = -1 });

            _questions.Add(new SingleSelectionQuestion
            {
                Id = ++_questionCounter,
                ExamId = _examCounter,
                Description = "Realiza las operaciones indicadas y elige la respuesta: \\[" +
                "(%m + x)^{2}(-1) - (%n - x)(%n + x)\\]"
            });
            _options.Add(new QuestionOption { Description = "\\(|-(%m * %m) - (%n * %n)| - |2*%m|x\\)", IsCorrect = true, Feedback = "Correcto", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(|-(%m * %m) - (%n * %n)|\\)", IsCorrect = false, Feedback = "Binomio al cuadrado como cuadrado de t�rminos.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(2x^{2} + |2*%m|x + |%m * %m - 1 - %n * %n|\\)", IsCorrect = false, Feedback = "Multiplicaci�n por -1 interpretada como resta.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(|-(%m * %m) - (%n * %n)| - |2 * %m|x - 2x^{2}\\)", IsCorrect = false, Feedback = "Olvido cambio de signo en segunda multiplicaci�n.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _variables.Add(new Variable { QuestionId = _questionCounter, Symbol = "m" });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "m", Id = ++_rangeCounter, Minimum = 1, Maximum = 3 });
            _variables.Add(new Variable { QuestionId = _questionCounter, Symbol = "n" });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 1, Maximum = 5 });

            _questions.Add(new SingleSelectionQuestion
            {
                Id = ++_questionCounter,
                ExamId = _examCounter,
                Description =  "Factoriza el t�rmino \\((x^2 - %m)\\) en la expresi�n \\[" +
                "(x^2 - %m)^2 + x^2(x^2 - %m)\\]"
            });
            _options.Add(new QuestionOption { Description = "\\((x^2 - %m)(2x^2 - %m)\\)", IsCorrect = true, Feedback = "Correcto", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(2x^4 - %mx^2 + |%m * %m|\\)", IsCorrect = false, Feedback = "Opera binomio al cuadrado como cuadrado de sus t�rminos.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(2x^4 - |3 * %m|x^2 + |%m * %m|\\)", IsCorrect = false, Feedback = "Realiza operaciones en lugar de factorizar.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\((x^2 - %m)^2(1 + x^2)\\)", IsCorrect = false, Feedback = "Expresi�n factorizada pero considerando el t�mino al cuadrado.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _variables.Add(new Variable { QuestionId = _questionCounter, Symbol = "m" });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "m", Id = ++_rangeCounter, Minimum = 1, Maximum = 4 });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "m", Id = ++_rangeCounter, Minimum = -4, Maximum = -1 });

            _questions.Add(new SingleSelectionQuestion
            {
                Id = ++_questionCounter,
                ExamId = _examCounter,
                Description = "Despeja 'y' de la ecuaci�n: \\[" +
                "%nx-|%n-1|y+|%n+2|=0\\]"
            });
            _options.Add(new QuestionOption { Description = "\\(y=\\dfrac{%nx}{|%n-1|} + \\dfrac{|%n+2|}{|%n-1|}\\)", IsCorrect = true, Feedback = "Correcto", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(y=\\dfrac{%nx}{|%n-1|} + |%n+2|\\)", IsCorrect = false, Feedback = "Falta pasar dividiendo en ambaos t�rminos.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(y=-\\dfrac{%nx}{|%n-1|} - \\dfrac{|%n+2|}{|%n-1|}\\)", IsCorrect = false, Feedback = "Signo al despejar.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(y=-\\dfrac{%nx}{|%n-1|} - |%n+2|\\)", IsCorrect = false, Feedback = "Signo al despejar y falta dividir ambos t�rminos.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _variables.Add(new Variable { QuestionId = _questionCounter, Symbol = "n" });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 3, Maximum = 3 });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 5, Maximum = 6 });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 8, Maximum = 10 });

            _questions.Add(new SingleSelectionQuestion
            {
                Id = ++_questionCounter,
                ExamId = _examCounter,
                Description = "Entre las siguiente opciones elige la que expresa correctamente el despeje de 'y' en la expresi�n: \\[" +
                "%m + %ny -x = 1\\]"
            });
            _options.Add(new QuestionOption { Description = "\\(y = \\dfrac{x + |1 - %m|}{%n}\\)", IsCorrect = true, Feedback = "Correcto", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(y=\\dfrac{x+|1+%m|}{%n}\\)", IsCorrect = false, Feedback = "Signo al pasar la constante al otro lado de la igualdad", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(y= \\dfrac{x+1}{%n}\\)", IsCorrect = false, Feedback = "Anula la constante del lado izquierdo.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(y= \\dfrac{x-%m}{%n}\\)", IsCorrect = false, Feedback = "Anula la constante del lado derecho.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _variables.Add(new Variable { QuestionId = _questionCounter, Symbol = "m" });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "m", Id = ++_rangeCounter, Minimum = 1, Maximum = 1 });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "m", Id = ++_rangeCounter, Minimum = 3, Maximum = 3 });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "m", Id = ++_rangeCounter, Minimum = 5, Maximum = 5 });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "m", Id = ++_rangeCounter, Minimum = 7, Maximum = 7 });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "m", Id = ++_rangeCounter, Minimum = 9, Maximum = 9 });
            _variables.Add(new Variable { QuestionId = _questionCounter, Symbol = "n" });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 2, Maximum = 2 });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 4, Maximum = 4 });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 6, Maximum = 6 });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 8, Maximum = 8 });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 10, Maximum = 10 });

            _questions.Add(new SingleSelectionQuestion
            {
                Id = ++_questionCounter,
                ExamId = _examCounter,
                Description = "Elige la expresi�n que se obitene al sustituir \\(y=x-2%n\\) en la expresi�n: \\[" +
                "x+y+%n=0\\]"
            });
            _options.Add(new QuestionOption { Description = "\\(2x-%n=0\\)", IsCorrect = true, Feedback = "Correcto", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(2x-|2*%n|=0\\)", IsCorrect = false, Feedback = "Anula la constante.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(x -% n = 0\\)", IsCorrect = false, Feedback = "Anula la primer 'x' al sustituir.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(x-|2*%n| =0\\)", IsCorrect = false, Feedback = "Anula la primer 'x' y la constante.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _variables.Add(new Variable { QuestionId = _questionCounter, Symbol = "n" });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 1, Maximum = 7 });

            _questions.Add(new SingleSelectionQuestion
            {
                Id = ++_questionCounter,
                ExamId = _examCounter,
                Description = "Factoriza \\(x^2\\) de la siguiente expresi�n: \\[" +
                "%mx^2+%nx^3\\]"
            });
            _options.Add(new QuestionOption { Description = "\\(x^2(%m+%nx)\\)", IsCorrect = true, Feedback = "Correcto", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(%mx(1+%nx)\\)", IsCorrect = false, Feedback = "Se enfoca en primer t�rmino completo.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(x^2%m + x^2%nx\\)", IsCorrect = false, Feedback = "Expresi�n cierta pero no factoriza.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\((%mx^2+%nx^2)x\\)", IsCorrect = false, Feedback = "Separa x para dejar x^2.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _variables.Add(new Variable { QuestionId = _questionCounter, Symbol = "n" });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 2, Maximum = 2 });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 4, Maximum = 4 });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 6, Maximum = 6 });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 8, Maximum = 8 });
            _variables.Add(new Variable { QuestionId = _questionCounter, Symbol = "m" });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "m", Id = ++_rangeCounter, Minimum = 3, Maximum = 3 });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "m", Id = ++_rangeCounter, Minimum = 5, Maximum = 5 });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "m", Id = ++_rangeCounter, Minimum = 7, Maximum = 7 });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "m", Id = ++_rangeCounter, Minimum = 9, Maximum = 9 });

            _questions.Add(new SingleSelectionQuestion
            {
                Id = ++_questionCounter,
                ExamId = _examCounter,
                Description = "Elige la expresi�n que resulta ser cierta cuando se trabajca algebra�camente la expresi�n: \\[" +
                "\\dfrac{1}{|2*%n|}x + \\dfrac{1}{|2*%n+1|} = 0\\]"
            });
            _options.Add(new QuestionOption { Description = "\\(|2*%n+1|x+2%n=0\\)", IsCorrect = true, Feedback = "Correcto", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(|2*%n+1|x+2%n=1\\)", IsCorrect = false, Feedback = "Considerar igualdad a 0 como igual a 1.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(|2*%n+1|x+2%n=|(2*%n)*(2*%n+1)|\\)", IsCorrect = false, Feedback = "Considerar 0=1 en el proceso.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(|2*%n|x+|2*%n+1|=|(2*%n)*(2*%n+1)|\\)", IsCorrect = false, Feedback = "Error al operar con el com�n denominador.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _variables.Add(new Variable { QuestionId = _questionCounter, Symbol = "n" });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 2, Maximum = 5 });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = -5, Maximum = -2 });

            _questions.Add(new SingleSelectionQuestion
            {
                Id = ++_questionCounter,
                ExamId = _examCounter,
                Description = "Despeja \\(x\\) de la expresi�n: \\[" +
                "%mx^2-|2*%m|=0\\]"
            });
            _options.Add(new QuestionOption { Description = "\\(x=\\pm\\sqrt{2}\\)", IsCorrect = true, Feedback = "Correcto", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(x=\\pm\\sqrt{|3*%m|}\\)", IsCorrect = false, Feedback = "Pasa m sumando a 2m.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(x=\\pm\\sqrt{|2*%m|}\\)", IsCorrect = false, Feedback = "Olivdo m en x^2.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(x=\\pm|2*%m|\\)", IsCorrect = false, Feedback = "Retro", Id = ++_optionCounter, QuestionId = _questionCounter });
            _variables.Add(new Variable { QuestionId = _questionCounter, Symbol = "m" });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "m", Id = ++_rangeCounter, Minimum = 4, Maximum = 9 });

            _questions.Add(new SingleSelectionQuestion
            {
                Id = ++_questionCounter,
                ExamId = _examCounter,
                Description = "Encuentra las soluciones de la ecuaci�n cuadr�tica siguiente: \\[" +
                "\\dfrac{%nx^2}{%m} - \\dfrac{x}{|%n+2|} =0\\]"
            });
            _options.Add(new QuestionOption { Description = "\\(x=0\\) y \\(x=\\dfrac{%m}{|%n*(%n+2)|}\\)", IsCorrect = true, Feedback = "Correcto", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(x=\\dfrac{%m}{|%n*(%n+2)|}\\)", IsCorrect = false, Feedback = "Cancela x sin considerar que x=0 es soluci�n.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(x=0\\) y \\(x=\\dfrac{%n}{|%m*(%n+2)|}\\)", IsCorrect = false, Feedback = "Despeja mal al pasar n�meros.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(x^2=\\dfrac{%m}{%n}\\) y \\(x=|%n+2|\\)", IsCorrect = false, Feedback = "Retro", Id = ++_optionCounter, QuestionId = _questionCounter });
            _variables.Add(new Variable { QuestionId = _questionCounter, Symbol = "m" });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "m", Id = ++_rangeCounter, Minimum = 2, Maximum = 2 });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "m", Id = ++_rangeCounter, Minimum = 4, Maximum = 4 });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "m", Id = ++_rangeCounter, Minimum = 8, Maximum = 8 });
            _variables.Add(new Variable { QuestionId = _questionCounter, Symbol = "n" });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 3, Maximum = 3 });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 5, Maximum = 5 });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 7, Maximum = 7 });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 9, Maximum = 9 });

            _questions.Add(new SingleSelectionQuestion
            {
                Id = ++_questionCounter,
                ExamId = _examCounter,
                Description = "Resuelve la ecuaci�n cuadr�tica y elige su soluci�n: \\[" +
                "|%n*%n|x^2-|%m*%m|=0\\]"
            });
            _options.Add(new QuestionOption { Description = "\\(x=\\dfrac{%m}{%n}\\) y \\(x=\\dfrac{-%m}{%n}\\)", IsCorrect = true, Feedback = "Correcto", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(x=\\dfrac{%n}{%m}\\) y \\(x=\\dfrac{-%n}{%m}\\)", IsCorrect = false, Feedback = "Despeje aml realizado.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(x=\\dfrac{%m}{%n}\\)", IsCorrect = false, Feedback = "No considera ambas opciones de signo.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(x^2=\\dfrac{|%m*%m|}{|%n*%n|}\\)", IsCorrect = false, Feedback = "No resuelve el despeje.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _variables.Add(new Variable { QuestionId = _questionCounter, Symbol = "m" });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "m", Id = ++_rangeCounter, Minimum = 2, Maximum = 2 });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "m", Id = ++_rangeCounter, Minimum = 4, Maximum = 4 });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "m", Id = ++_rangeCounter, Minimum = 8, Maximum = 8 });
            _variables.Add(new Variable { QuestionId = _questionCounter, Symbol = "n" });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 3, Maximum = 3 });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 5, Maximum = 5 });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 7, Maximum = 7 });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 9, Maximum = 9 });

            _questions.Add(new SingleSelectionQuestion
            {
                Id = ++_questionCounter,
                ExamId = _examCounter,
                Description = "Entre las siguientes expresiones cuadr�ticas, elige la que toma valores positivos siempre, independientemente del valor designado a 'x'."
            });
            _options.Add(new QuestionOption { Description = "\\(%nx^2+%m\\)", IsCorrect = true, Feedback = "Correcto", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(|%n*%n|x^2-%m\\)", IsCorrect = false, Feedback = "Se prejuicia observando los n�meros.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(x^2 + %mx + 1\\)", IsCorrect = false, Feedback = "Se prejuiciia con los signos positivos en la expresi�n.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(x^2 + %mx -1\\)", IsCorrect = false, Feedback = "Se prejuicia evaluando en enteros positivos.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _variables.Add(new Variable { QuestionId = _questionCounter, Symbol = "m" });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "m", Id = ++_rangeCounter, Minimum = 3, Maximum = 5 });
            _variables.Add(new Variable { QuestionId = _questionCounter, Symbol = "n" });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 2, Maximum = 2 });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 4, Maximum = 4 });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 6, Maximum = 6 });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 8, Maximum = 8 });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 10, Maximum = 10 });

            _questions.Add(new SingleSelectionQuestion
            {
                Id = ++_questionCounter,
                ExamId = _examCounter,
                Description = "Encuentra todos los valores de x que satisfacen la ecuaci�n: \\[" +
                "\\dfrac{%n-x^2}{x^2}=0\\]"
            });
            _options.Add(new QuestionOption { Description = "\\(x=\\pm\\sqrt{%n}\\)", IsCorrect = true, Feedback = "Correcto", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(x=\\pm\\sqrt{\\dfrac{1}{%n}}\\)", IsCorrect = false, Feedback = "Despeja mal al pasar dividiendo.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(x=\\pm %n\\)", IsCorrect = false, Feedback = "No despeja el cuadrado.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(x=\\pm\\sqrt{\\dfrac{%n}{2}}\\)", IsCorrect = false, Feedback = "Pasa x^2 multiplicando por 1 en vez de por 0.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _variables.Add(new Variable { QuestionId = _questionCounter, Symbol = "n" });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 3, Maximum = 3 });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 5, Maximum = 5 });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 7, Maximum = 7 });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 11, Maximum = 11 });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 13, Maximum = 13 });

            _questions.Add(new SingleSelectionQuestion
            {
                Id = ++_questionCounter,
                ExamId = _examCounter,
                Description = "Resuelve la ecuaci�n cuadr�tica y elige sus soluciones: \\[" +
                "x^2 - %nx - 1 = 0\\]"
            });
            _options.Add(new QuestionOption { Description = "\\(x=\\dfrac{%n+\\sqrt{|%n*%n+4|}}{2}\\), \\(x=\\dfrac{%n-\\sqrt{|%n*%n+4|}}{2}\\)", IsCorrect = true, Feedback = "Correcto", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(x=1\\), \\(x=%n\\)", IsCorrect = false, Feedback = "Opera x^2-nx=1 igualando los factores a 1.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(x=\\sqrt{%nx+1}\\), \\(x=-\\sqrt{%nx+1}\\)", IsCorrect = false, Feedback = "Despeja de x^2 sin condierar x.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "No tiene soluci�n", IsCorrect = false, Feedback = "No puede resolverlo.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _variables.Add(new Variable { QuestionId = _questionCounter, Symbol = "n" });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 2, Maximum = 7 });

            _questions.Add(new SingleSelectionQuestion
            {
                Id = ++_questionCounter,
                ExamId = _examCounter,
                Description = "En la sigueinte ecuaci�n sustituye \\(y=\\dfrac{1}{%n}\\) y obt�n el valor de x: \\[" +
                "|2*%n| - %nx + \\dfrac{y}{%n} = 0\\]"
            });
            _options.Add(new QuestionOption { Description = "\\(x=\\dfrac{|2*%n*%n*%n+1|}{|%n*%n*%n|}\\)", IsCorrect = true, Feedback = "Correcto", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(x=\\dfrac{|2*%n-1|}{%n}\\)", IsCorrect = false, Feedback = "Al sustituir opera como y=n", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(x=-\\dfrac{1}{|%n*%n*%n|}\\)", IsCorrect = false, Feedback = "Resta los 2 primeros t�rminos como si tuvieran x ambos.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _options.Add(new QuestionOption { Description = "\\(x=-\\dfrac{1}{%n}\\)", IsCorrect = false, Feedback = "Resta 2 primeros t�rminos y sustituye y=n.", Id = ++_optionCounter, QuestionId = _questionCounter });
            _variables.Add(new Variable { QuestionId = _questionCounter, Symbol = "n" });
            _ranges.Add(new Range { QuestionId = _questionCounter, Symbol = "n", Id = ++_rangeCounter, Minimum = 2, Maximum = 5 });
        }
    }
}