$(function () {
    var ctx3 = document.getElementById("exampleChart3").getContext("2d");
    var chart = new Chart(ctx3, {
        // The type of chart we want to create
        type: "line",

        // The data for our dataset
        data: {
            labels: ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"],
            datasets: [
                {
                    label: "Pedidos",
                    backgroundColor: "rgb(255, 99, 132)",
                    borderColor: "rgb(255, 99, 132)",
                    data: [0, 10, 5, 2, 20, 30, 45, 20, 10, 30, 50, 60]
                }
            ]
        },

        // Configuration options go here
        options: {}
    });
});