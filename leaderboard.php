<?php
header("Content-Type: application/json");

$file = "leaderboard.json";

// --- GET: получить топ 10 ---
if ($_SERVER['REQUEST_METHOD'] === 'GET') {
    if (!file_exists($file)) {
        echo json_encode([]);
        exit;
    }

    echo file_get_contents($file);
    exit;
}

// --- POST: добавить результат ---
if ($_SERVER['REQUEST_METHOD'] === 'POST') {

    $name = isset($_POST['name']) ? strip_tags($_POST['name']) : "Player";
    $score = isset($_POST['score']) ? intval($_POST['score']) : 0;

    if (!file_exists($file)) {
        file_put_contents($file, json_encode([]));
    }

    $data = json_decode(file_get_contents($file), true);

    if (!is_array($data)) {
        $data = [];
    }

    $data[] = [
        "name" => substr($name, 0, 20),
        "score" => $score
    ];

    // сортировка по убыванию
    usort($data, function($a, $b) {
        return $b['score'] <=> $a['score'];
    });

    // оставляем только топ 10
    $data = array_slice($data, 0, 10);
    // безопасная запись с блокировкой
    file_put_contents($file, json_encode($data, JSON_PRETTY_PRINT), LOCK_EX);

    echo json_encode(["status" => "saved"]);
}
?>