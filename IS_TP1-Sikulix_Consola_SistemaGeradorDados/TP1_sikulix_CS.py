from sikuli import *
import httplib
import json
import time
import os

# Configuração do sistema de logs
LOG_DIR = "C:\Users\pauli\Desktop"
LOG_FILE = os.path.join(LOG_DIR, "TP1_sikulix_log_{}.txt")
#################################

def write_log(message):
    """Escreve mensagem no log com timestamp"""
    timestamp = time.strftime("%Y-%m-%d %H:%M:%S")
    log_entry = "[{}] {}\n".format(timestamp, message)
    with open(LOG_FILE, "a") as f:
        f.write(log_entry)
    print(log_entry.strip())

# Configurações
console_region = Region(51,111,310,28)
API_HOST = "127.0.0.1"
API_PORT = 5077
API_ENDPOINT = "/api/Produto"

write_log("=== INÍCIO DA EXECUÇÃO ===")

def validar_tempo(tempo):
    """Garante que o tempo de produção está entre 10 e 50"""
    try:
        tempo_int = int(tempo)
        return max(10, min(50, tempo_int))
    except:
        return 30  # Valor padrão se a conversão falhar

def formatar_hora(hora_str):
    """Garante o formato HH:MM:SS"""
    try:
        if len(hora_str.split(":")) == 2:  # Se só tiver horas e minutos
            return hora_str + ":00"
        return hora_str
    except:
        return "00:00:00"  # Valor padrão

def formatar_data(data_str):
    """Converte data de DD/MM/AAAA para AAAA-MM-DD"""
    try:
        dia, mes, ano = data_str.split("/")
        return "{}-{}-{}".format(ano, mes, dia)
    except:
        return time.strftime("%Y-%m-%d")  # Data atual se a conversão falhar

def test_api_connection():
    try:
        conn = httplib.HTTPConnection(API_HOST, API_PORT, timeout=5)
        conn.request("GET", "/")
        conn.close()
        write_log("Teste de conexão com API: OK")
        return True
    except Exception as e:
        write_log("!!️ Falha no teste de conexão com API: " + str(e))
        return False

# Verificação inicial
if not test_api_connection():
    popup("API não está a responder!\nVerifique o servidor.\nLogs em: " + LOG_FILE)
    write_log("API inacessível - Encerrando script")
    exit()

# Loop principal
write_log("Iniciar loop principal de captura...\n")
try:
    while True:
        try:
            # Captura de texto
            linha_texto = console_region.text()
            if not linha_texto:
                wait(1)
                continue

            write_log("Texto capturado: " + str(linha_texto))

            # Processamento dos dados
            try:
                dados = [d.strip() for d in linha_texto.split(";") if d.strip()]
                if len(dados) < 4:
                    write_log("- Dados insuficientes (necessário 4 campos)\n\n\n")
                    continue

                # Construção do payload com formatação correta
                payload = {
                    "Produto": {  
                        "Codigo_Peca": dados[0],
                        "Data_Producao": formatar_data(dados[1]),
                        "Hora_Producao": formatar_hora(dados[2]),
                        "Tempo_Producao": validar_tempo(dados[3])
                    }
                }

                json_payload = json.dumps(payload)
                write_log("JSON preparado: " + json_payload)

                # Método 1: httplib (padrão)
                try:
                    write_log("Tentando envio via httplib...")
                    conn = httplib.HTTPConnection(API_HOST, API_PORT, timeout=10)
                    headers = {
                        "Content-Type": "application/json",
                        "Accept": "application/json"
                    }
                    conn.request("POST", API_ENDPOINT, json_payload, headers)
                    response = conn.getresponse()
                    response_body = response.read()
                    write_log("Resposta HTTP {}: {}".format(response.status, response_body))
                    conn.close()
                    
                    if response.status == 200:
                        write_log("+ Dados enviados com sucesso!\n")
                    else:
                        write_log("- Erro no envio dos dados!\n")
                    
                except Exception as http_err:
                    write_log("- Falha no httplib: " + str(http_err))

            except ValueError as e:
                write_log("- Erro nos dados: " + str(e))
            except Exception as e:
                write_log("- Erro inesperado: " + str(e))

        except Exception as e:
            write_log("--- ERRO NO LOOP: " + str(e))

        wait(10) #Intervalo entre cada captura de dados (ajustável)

except Exception as e:
    write_log("--- ERRO GRAVE: " + str(e))
    popup("Erro grave - Verifique os logs em: " + LOG_FILE)
finally:
    write_log("=== FIM DA EXECUÇÃO ===")
    popup("Script finalizado. Logs salvos em: " + LOG_FILE)
