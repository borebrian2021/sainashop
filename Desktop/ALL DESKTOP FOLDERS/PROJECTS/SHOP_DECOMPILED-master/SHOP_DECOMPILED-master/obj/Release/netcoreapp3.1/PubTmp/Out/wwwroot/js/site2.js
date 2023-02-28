

function generateBarcode_(num) {
    $("barcodeValue").value = num;
    generateBarcode();
}

    function generateBarcode() {
        $("barcodeTarget").update();
        var value = $("barcodeValue").value;
    var btypeGrp = document['forms']['form']['btype'];
    for(i=0; i < btypeGrp.length; i++){
          if (btypeGrp[i].checked == true) {
            var btype = btypeGrp[i].value;
          }
        }
    var rendererGrp = document['forms']['form']['renderer'];
    for(i=0; i < rendererGrp.length; i++){
          if (rendererGrp[i].checked == true) {
            var renderer = rendererGrp[i].value;
          }
        }

    var settings = {
        output:renderer,
    bgColor: $("bgColor").value,
    color: $("color").value,
    barWidth: $("barWidth").value,
    barHeight: $("barHeight").value,
    moduleSize: $("moduleSize").value,
    posX: $("posX").value,
    posY: $("posY").value,
    addQuietZone: false
        };
    if ($("rectangular").checked){
        value = { code: value, rect: true };
        }
    if (renderer == 'canvas'){
        clearCanvas();
    $("barcodeTarget").hide();
    $("canvasTarget").show().barcode(value, btype, settings);
        } else {
        $("canvasTarget").hide();
    $("barcodeTarget").update().show().barcode(value, btype, settings);
        }
      }

    function showConfig( event ){
        var element = Event.element(event);
    if (element.id ==  'datamatrix') {
        $('barcode1D').hide();
    $('barcode2D').show();
        } else {
        $('barcode1D').show();
    $('barcode2D').hide();
        }
      }

    function showConfigRenderer( event ){
        var element = Event.element(event);
    if (element.id ==  'canvas') {
        $('miscCanvas').show();
        } else {
        $('miscCanvas').hide();
        }
      }

    function clearCanvas(){
        var canvas = $('canvasTarget');
    var ctx = canvas.getContext('2d');
    ctx.lineWidth = 1;
    ctx.lineCap = 'butt';
    ctx.fillStyle = '#FFFFFF';
    ctx.strokeStyle  = '#000000';
    ctx.clearRect (0, 0, canvas.width, canvas.height);
    ctx.strokeRect (0, 0, canvas.width, canvas.height);
      }

    Event.observe(window, 'load', function() {
        var btypeGrp = document['forms']['form']['btype'];
    for(i=0; i < btypeGrp.length; i++){
        $(btypeGrp[i].id).observe('click', showConfig);
        }
    var btypeRdr = document['forms']['form']['renderer'];
    for(i=0; i < btypeRdr.length; i++){
        $(btypeRdr[i].id).observe('click', showConfigRenderer);
        }
    $('ean8').click();
    $('css').click();
    });


    $(function(){
        $('input[name=btype]').click(function () {
            if ($(this).attr('id') == 'datamatrix') showConfig2D(); else showConfig1D();
        });
    $('input[name=renderer]').click(function(){
          if ($(this).attr('id') == 'canvas') $('miscCanvas').show(); else $('miscCanvas').hide();
        });
    generateBarcode('758804');
      });
