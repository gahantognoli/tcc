$(function () {
    //charts
    var ctx = document.getElementById("exampleChart").getContext("2d");
    var myChart = new Chart(ctx, {
        type: "bar",
        data: {
            labels: ["Red", "Blue", "Yellow", "Green", "Purple", "Orange"],
            datasets: [
                {
                    label: "# of Votes",
                    data: [12, 19, 3, 5, 2, 3],
                    backgroundColor: [
                        "rgba(255, 99, 132, 0.8)",
                        "rgba(54, 162, 235, 0.8)",
                        "rgba(255, 206, 86, 0.8)",
                        "rgba(75, 192, 192, 0.8)",
                        "rgba(153, 102, 255, 0.8)",
                        "rgba(255, 159, 64, 0.8)"
                    ],
                    borderColor: [
                        "rgba(255, 99, 132, 1)",
                        "rgba(54, 162, 235, 1)",
                        "rgba(255, 206, 86, 1)",
                        "rgba(75, 192, 192, 1)",
                        "rgba(153, 102, 255, 1)",
                        "rgba(255, 159, 64, 1)"
                    ],
                    borderWidth: 1
                }
            ]
        },
        options: {
            scales: {
                yAxes: [
                    {
                        ticks: {
                            beginAtZero: true
                        }
                    }
                ]
            }
        }
    });

    var ctx2 = document.getElementById("exampleChart2").getContext("2d");
    var myPieChart = new Chart(ctx2, {
        type: "pie",
        data: {
            labels: ["January", "February", "March", "April", "May", "June", "July"],
            datasets: [
                {
                    label: "My First dataset",
                    backgroundColor: [
                        "rgba(105, 129, 132, 0.8)",
                        "rgba(54, 162, 235, 0.8)",
                        "rgba(255, 206, 86, 0.8)",
                        "rgba(75, 192, 192, 0.8)",
                        "rgba(153, 102, 255, 0.8)",
                        "rgba(225, 139, 24, 0.8)",
                        "rgba(255, 159, 64, 0.8)"
                    ],
                    data: [0, 10, 5, 2, 20, 30, 45]
                }
            ]
        },

        // Configuration options go here
        options: {}
    });

    var ctx3 = document.getElementById("exampleChart3").getContext("2d");
    var chart = new Chart(ctx3, {
        // The type of chart we want to create
        type: "line",

        // The data for our dataset
        data: {
            labels: ["January", "February", "March", "April", "May", "June", "July"],
            datasets: [
                {
                    label: "My First dataset",
                    backgroundColor: "rgb(255, 99, 132)",
                    borderColor: "rgb(255, 99, 132)",
                    data: [0, 10, 5, 2, 20, 30, 45]
                }
            ]
        },

        // Configuration options go here
        options: {}
    });

    var ctx4 = document.getElementById("exampleChart4").getContext("2d");
    var myDoughnutChart = new Chart(ctx4, {
        type: "doughnut",
        data: {
            labels: ["January", "February", "March", "April", "May", "June", "July"],
            datasets: [
                {
                    label: "My First dataset",
                    backgroundColor: [
                        "rgba(2, 10, 121, 0.8)",
                        "rgba(78, 22, 22, 0.8)",
                        "rgba(111, 226, 96, 0.8)",
                        "rgba(235, 122, 112, 0.8)",
                        "rgba(200, 20, 255, 0.8)",
                        "rgba(161, 169, 224, 0.8)",
                        "rgba(10, 159, 64, 0.8)"
                    ],
                    data: [0, 10, 5, 2, 20, 30, 45]
                }
            ]
        },

        // Configuration options go here
        options: {}
    });
});