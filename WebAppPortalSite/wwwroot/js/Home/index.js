$(document).ready(function () {
    LoadSummary();
    LoadSalesChart();
});


function LoadSummary() {
    $.ajax({
        url: '/Home/LoadSummary',
        type: 'GET',
        success: function (response) {
            if (response.responseCode == 1) {
                SetErrors("#homeValidation", response.errors);
                return;
            }

            if (response.responseCode != 2) {
                alert(response.message);
                return;
            }


            let summary = response.data;


            $("#totalUsers").text(summary.totalUsers);
            $("#totalActiveUsers").text(summary.totalActiveUsers);
            $("#totalProducts").text(summary.totalProducts);
            $("#topWeeklyUser").text(summary.topWeeklyUser || "-");

            LoadUserChart(summary);

        },
        error: function (xhr) {
            alert("Error loading");
        },
        complete: function () {
      
        }
    });
} 


function LoadUserChart(summary) {
    const ctx = document.getElementById("userChart").getContext("2d");

    new Chart(ctx, {
        type: "doughnut",
        data: {
            labels: ["Active", "Inactive"],
            datasets: [{
                data: [
                    summary.totalActiveUsers,
                    summary.totalUsers - summary.totalActiveUsers
                ],
                backgroundColor: ["rgba(40, 167, 69, 0.9)", "rgba(224, 224, 224, 0.6)"],
                borderWidth: 0,
                hoverOffset: 10
            }]
        },
        options: {
            responsive: true,
            plugins: {
                legend: {
                    position: "bottom",
                    labels: { font: { size: 14 } }
                }
            }
        }
    });
}

function LoadSalesChart() {
    const ctx = document.getElementById('salesChart').getContext('2d');
    const salesChart = new Chart(ctx, {
        type: 'bar', 
        data: {
            labels: ['January', 'February', 'March', 'April', 'May'],
            datasets: [{
                label: 'Sales (R)',
                data: [12000, 19000, 3000, 5000, 20000],
                backgroundColor: [
                    'rgba(54, 162, 235, 0.6)',
                    'rgba(255, 99, 132, 0.6)',
                    'rgba(255, 206, 86, 0.6)',
                    'rgba(75, 192, 192, 0.6)',
                    'rgba(153, 102, 255, 0.6)'
                ],
                borderColor: 'rgba(0,0,0,0.1)',
                borderWidth: 1
            }]
        },
        options: {
            responsive: true,
            plugins: {
                legend: { position: 'top' },
                title: { display: true, text: 'Monthly Sales Performance' }
            }
        }
    });

}