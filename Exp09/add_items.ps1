$products = @(
    @{"Name"="Mechanical Gaming Keyboard"; "Price"=2499.00},
    @{"Name"="24-inch 144Hz Gaming Monitor"; "Price"=12499.00},
    @{"Name"="Noise Canceling Wireless Headphones"; "Price"=3999.00},
    @{"Name"="500GB Portable SSD"; "Price"=5200.00},
    @{"Name"="Logitech C922 HD Webcam"; "Price"=8450.00},
    @{"Name"="High-Back Ergonomic Office Chair"; "Price"=9999.00}
)

Write-Host "Adding new products..."
foreach ($p in $products) {
    $body = $p | ConvertTo-Json
    Invoke-RestMethod -Uri "http://localhost:5202/api/Products" -Method POST -Headers @{"Content-Type"="application/json"} -Body $body | Out-Null
}
Write-Host "Added new products successfully."

Write-Host "Updating Wireless Mouse price..."
$all = Invoke-RestMethod -Uri "http://localhost:5202/api/Products" -Method GET
$mouse = $all | Where-Object { $_.name -eq "Wireless Mouse" }
if ($mouse) {
    $mouse.price = 500.00
    $body = $mouse | ConvertTo-Json
    Invoke-RestMethod -Uri "http://localhost:5202/api/Products/$($mouse.id)" -Method PUT -Headers @{"Content-Type"="application/json"} -Body $body | Out-Null
    Write-Host "Wireless Mouse price updated to 500.00."
} else {
    Write-Host "Wireless Mouse not found."
}
