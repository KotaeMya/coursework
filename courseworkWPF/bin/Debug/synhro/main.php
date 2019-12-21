<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>   
<link rel="stylesheet" href="../25/css/template.css" type="text/css" />
<title>Страница</title>
<meta charset="utf-8">
</head>
<body>
<form method="post" action="text.php">
	<p class="element">Вариант задания № 6</p>
	<p class="element">"Тест"</p>
	<div class="element">
		<p><strong>Вопрос №1:</strong> Сколько колец на Олимпийском флаге?</p>
		<p><input type="radio" name="capital" value="5"> 5</p>
		<p><input type="radio" name="capital" value="7"> 7</p>
		<p><input type="radio" name="capital" value="4"> 4</p>
		<p><input type="radio" name="capital" value="6"> 6</p>
	</div>
	<div class="element">
		<p><strong>Вопрос №2:</strong> Сколько будет (5 + 5 + 5) - (5 + 5) * 0</p>
		<p><input type="text" name="matematic" placeholder="Введите сюда ответ" /></p>
	</div>
	<div class="element">
		<p><strong>Вопрос №3:</strong> Вы счастливый человек? (Правильный ответ - Да! ^_^)</p>
		<p><input type="radio" name="happy" value="Да"> Да</p>
		<p><input type="radio" name="happy" value="Нет"> Нет</p>
	</div>
	<div class="element">
		<p><strong>Вопрос №4:</strong> Какой продукт питания никогда не портится?</p>
		<p><input type="radio" name="product" value="Мед"> Мед</p>
		<p><input type="radio" name="product" value="Черный перец"> Черный перец</p>
		<p><input type="radio" name="product" value="Сушенные овощи"> Сушенные овощи</p>
		<p><input type="radio" name="product" value="Оливковое масло"> Оливковое масло</p>
	</div>
	<div class="element">
		<p><strong>Вопрос №5:</strong> Инсулин в организме человека вырабатывает </p>
		<p><input type="radio" name="insuline" value="Печень"> Печень</p>
		<p><input type="radio" name="insuline" value="Поджелудочная железа"> Поджелудочная железа</p>
		<p><input type="radio" name="insuline" value="Щитовидная железа"> Щитовидная железа</p>
		<p><input type="radio" name="insuline" value="Слюнная железа"> Слюнная железа</p>
	</div>

	<div class="element">
		<p><strong>Вопрос №6:</strong> Выберите женские имена </p>
		<p><input type="checkbox" name="gender1" value="Маша"> Маша</p>
		<p><input type="checkbox" name="gender2" value="Дима">Дима</p>
		<p><input type="checkbox" name="gender3" value="Марина"> Марина</p>
		<p><input type="checkbox" name="gender4" value="Алексей"> Алексей</p>
		<p><input type="checkbox" name="gender5" value="Александр"> Александр</p>
		
	</div>
	<div class="element">
		<p><input type="submit" value="Отправить ответы" /></p>
	</div>
	<p class="element">Работу выполнила студентка группы 621пст</p>
	<p class="element">Козаченко Диана Юрьевна</p>
	<SCRIPT>
	d = new Date();
	document.write('Момент загрузки страницы: '
	+ d.getHours() + ':'
	+ d.getMinutes() + ':'
	+ d.getSeconds());
	</SCRIPT>
	
</form>
</body>
</html>
