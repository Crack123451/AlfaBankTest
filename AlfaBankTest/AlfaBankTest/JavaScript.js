$.get('http://localhost:65506/api/values/?request=count',
    function (data) {
        document.getElementById('count').innerHTML = data;
        Count.count = data;
    });
$.get('http://localhost:65506/api/values/?request=maxPrice',
    function (data) {
        document.getElementById('maxPrice').innerHTML = data;
    });
$.get('http://localhost:65506/api/values/?request=minPrice',
    function (data) {
        document.getElementById('minPrice').innerHTML = data;
    });
$.get('http://localhost:65506/api/values/?request=averagePrice',
    function (data) {
        document.getElementById('averagePrice').innerHTML = data;
    });

$(function () {
    for (id = 0; id < 20; id++) {
        $.get('http://localhost:65506/api/values/' + id,
            function (data) {
                if (data !== null) {
                    tbody.innerHTML+= "<tr><td>" + data[0] + "</td>" +
                        "<td>" + data[1] + "</td>" +
                        "<td>" + data[2] + "</td>" +
                        "<td>" + data[3] + "</td>" +
                        "<td>" + data[4] + "</td>" +
                        "<td>" + data[5] + "</td>" +
                        "<td>" + data[6] + "</td>" +
                        "<td>" + data[7] + "</td>" +
                        '<td><img src=' + data[8] + ' alt="Фото недоступно"></td></tr>';
                }
            });
    }
});