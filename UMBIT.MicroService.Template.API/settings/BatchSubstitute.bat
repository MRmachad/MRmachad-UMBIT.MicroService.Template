@echo off
setlocal enabledelayedexpansion

rem Verifica se o número de argumentos é correto
if "%~3"=="" (
    echo Uso: %0 "arquivo_origem" "arquivo_destino" "string_antiga" "string_nova"
    exit /b
)

set "arquivo_origem=%~1"
set "arquivo_destino=%~2"
set "string_antiga=%~3"
set "string_nova=%~4"

set "tempfile=%temp%\tempfile.txt"

rem Leitura do arquivo JSON
(for /f "delims=" %%a in ('type %arquivo_origem%') do (
    set "linha=%%a"
    
    rem Realiza a substituição apenas se a linha contiver a string antiga
    if not "!linha:%string_antiga%=!"=="!linha!" (
        set "linha=!linha:%string_antiga%=%string_nova%!"
    )

    echo !linha!
)) > %tempfile%

rem Move o arquivo temporário de volta para o arquivo original
move /y %tempfile% %arquivo_destino%

echo Substituição concluída. Resultado salvo em %arquivo_destino%.
