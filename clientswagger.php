<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Get Data from REST API</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            padding: 20px;
        }
        pre {
            background-color: #f4f4f4;
            padding: 10px;
            border: 1px solid #ddd;
        }
        .error {
            color: red;
        }
    </style>
</head>
<body>
    <h1>Student Data</h1>
    <?php
    $url = 'http://localhost:8080/swagger/v1/swagger.json';

    try {
        $json = file_get_contents($url);
        if ($json === FALSE) {
            throw new Exception('Error fetching data.');
        }
        $data = json_decode($json, true);
        if (json_last_error() !== JSON_ERROR_NONE) {
            throw new Exception('Error decoding JSON: ' . json_last_error_msg());
        }
        echo '<pre>' . json_encode($data, JSON_PRETTY_PRINT) . '</pre>';
    } catch (Exception $e) {
        echo '<p class="error">Error: ' . $e->getMessage() . '</p>';
    }
    ?>
</body>
</html>