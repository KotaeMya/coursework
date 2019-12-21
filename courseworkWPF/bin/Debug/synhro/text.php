
<?php

function init() {
	$array = array(
		"5",
		 "15",
		  "Да",
		   "Мед",
			"Поджелудочная железа",
			 "Маша",
			 "Марина"
			 );
	
		//Получаем данные из глобальной переменной $_POST, так как мы передаем данные методом POST
		$capital = $_POST['capital'] ?? ''; // Вытаскиваем ответ на первый вопрос в переменную
		$matematic = $_POST['matematic'] ?? ''; // Вытаскиваем ответ на второй вопрос в переменную
		$happy = $_POST['happy'] ?? ''; // Вытаскиваем ответ на третий вопрос в переменную
		$product = $_POST['product'] ?? '';
		$insuline = $_POST['insuline'] ?? '';
	
		/* Вопрос с несколькими вариантами ответов */

		$hgender = array(
			$_POST['gender1'] ?? '',
			$_POST['gender2'] ?? '',
			$_POST['gender3'] ?? '',
			$_POST['gender4'] ?? '',
			$_POST['gender5'] ?? ''
		);

		[$capital, $matematic, $happy, $product, $insuline] = example();

		$result = 0; // результат будет в процентах правильных ответов
		$result += first($capital, $array);
		$result += second($matematic, $array);
		$result += third($happy, $array);
		$result += fourth($product, $array);
		$result += fifth($insuline, $array);
		$result += sixth($hgender, $array);
		result($result);
}
	init();

	function first($capital = 0, $array) {
		/* проверяем первый вопрос */
		if ($capital == $array[0]) {
			echo 'Вопрос №1: Сколько колец на Олимпийском флаге?', '<p style="color: green;"><strong>', $capital, '</strong></p>';
			return 1;
		}
		else {
			echo 'Вопрос №1: Сколько колец на Олимпийском флаге?', 'Вопрос №1: Сколько колец на Олимпийском флаге?',  '<p style="color: red;">', $capital, '</p>';
			return 0;
		}
	}
		
	function second($matematic = 0, $array) {
		/* проверяем второй вопрос */
		if ($matematic == $array[1]) {
			echo 'Вопрос №2: Сколько будет (5 + 5 + 5) - (5 + 5) * 0', '<p style="color: green;">', $matematic, '</p>';
			return 1;
		}
		else {
			echo 'Вопрос №2: Сколько будет (5 + 5 + 5) - (5 + 5) * 0', '<p style="color: red;">', $matematic, '</p>';
			return 0;
		}
	}

	function third($happy = 'Да', $array) {
		/* проверяем третий вопрос */
		if ($happy == $array[2]) {
			echo 'Вопрос №3: Вы счастливый человек? (Правильный ответ - Да! ^_^)', '<p style="color: green;">', $happy, '</p>';
			return 1;
		}
		else {
			echo 'Вопрос №3: Вы счастливый человек? (Правильный ответ - Да! ^_^)', '<p style="color: red;">', $happy, '</p>';
			return 0;
		}
	}

	function fourth($product = 'Мед', $array) {
		if ($product == $array[3]) {
			echo 'Вопрос №4: Какой продукт питания никогда не портится?', '<p style="color: green;">', $product, '</p>';
			return 1;
		}
		else {
			echo 'Вопрос №4: Какой продукт питания никогда не портится?', '<p style="color: red;">', $product, '</p>';
			return 0;
		}
	}

	function fifth($insuline = 'Инсулин', $array) {
		if ($insuline == $array[4]) {
			echo 'Вопрос №5: Инсулин в организме человека вырабатывает', '<p style="color: green;">', $insuline, '</p>';
			return 1;
		}
		else {
			echo 'Вопрос №5: Инсулин в организме человека вырабатывает', '<p style="color: red;">', $insuline, '</p>';
			return 0;
		}
	}

	function sixth($hgender, $array) {
		/* Проверяем вопрос */
		$subresult = 0; // дополнительная переменная для подсчёта правильности ответов

			/* если мужское имя выбрано правильно то увеличиваем счётчик */
		if ($hgender[0] == $array[5]) {
			$subresult +=0.5;
			echo 'Вопрос №6: Выберите женские имена: ', '<p style="color: green;">', $hgender[0], '</p>';
		}

		if ($hgender[1] == 'Дима') {
			$subresult -=0.5;
			echo '<p style="color: red;">', $hgender[1], '</p>';
		}

		if ($hgender[2] == $array[6]) {
			$subresult += 0.5;
			echo '<p style="color: green;">', $hgender[2], '</p>';
		}

		if ($hgender[3] == 'Алексей') {
			$subresult -= 0.5;
			echo '<p style="color: red;">', $hgender[3], '</p>';
		}

		if ($hgender[4] == 'Александр') {
			$subresult -= 0.5;
			echo '<p style="color: red;">', $hgender[4], '</p>';
		}

		if ($subresult == 1) {
			return 1;
		} else {
			return 0;
		}
	}

	function result($result = 0) {
		echo '<p> Вы набрали: ', $result, ' балла(ов)</p>';
	}

	function example() {
		return [
			"5",
			"15",
			"Да",
			"Мед",
			"Поджелудочная железа"
			];
	}

?>

