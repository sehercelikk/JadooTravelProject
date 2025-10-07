$(function () {
    $(function () {
        fetch('/Statistics/GetTourCapacity') // JSON endpoint
            .then(response => response.json())
            .then(data => {
                // MongoDB’den gelen veri
                const categories = data.map(x => x.cityCountry);
                const capacities = data.map(x => x.capacity);

                var profit = {
                    series: [
                        { name: "Kapasite", data: capacities }
                    ],
                    chart: {
                        type: "bar",
                        height: 360,
                        toolbar: { show: false }
                    },
                    plotOptions: { bar: { horizontal: false, columnWidth: "30%", endingShape: "flat" } },
                    dataLabels: { enabled: false },
                    stroke: { show: true, width: 5, colors: ["transparent"] },
                    xaxis: { categories: categories },
                    yaxis: {},
                    colors: ["#1e88e5"],
                    tooltip: { theme: "dark" }
                };

                var chart = new ApexCharts(document.querySelector("#profit"), profit);
                chart.render();
            })
            .catch(err => console.error("Grafik yüklenirken hata:", err));
    });

});