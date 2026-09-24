click(Pattern("1743155421234.png").targetOffset(-205,-109))
while True:  

    doubleClick(Pattern("1743215680849.png").targetOffset(-239,-44)) 
    type("c", Key.CTRL)
    #codigo
    click(Pattern("1743155603255.png").targetOffset(-43,-28))
    type("v", Key.CTRL)

    doubleClick(Pattern("1743155780265.png").targetOffset(-225,10))
    type("c", Key.CTRL)
    #data

    click(Pattern("1743155809148.png").targetOffset(-61,6))
    type("v", Key.CTRL)
    doubleClick(Pattern("1743216475521.png").targetOffset(-129,67))
    type("c", Key.CTRL)
    #horas
    click(Pattern("1743215836396.png").targetOffset(-74,38))
    type("v", Key.CTRL)
    doubleClick(Pattern("1743159905449.png").targetOffset(-255,114))    
    type("c", Key.CTRL)
    ##########tempo = App.getClipboard()
    #tempo
    click(Pattern("1743180027972.png").targetOffset(-76,75))
    type("v", Key.CTRL)
    #guardar
    click(Pattern("1743179604539.png").targetOffset(75,72))
    click(Pattern("1743117693225.png").targetOffset(70,56))
    
    # Usar o tempo capturado no wait()
    try:
        #tempo_float = float(tempo)  # Converter o tempo para número
        wait(3)  # Espera pelo tempo capturado
        ##Consegue-se sincronizaçao assim... entre o tempo que demora a gerar os dados e o tempo que demora a copiar e inserir os dados no sistema legado
    except ValueError:
        wait(40)

    