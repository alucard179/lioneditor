@for %%i in (%1\Resources\PSP\*.xml) do "%1\gzip" -c "%%i" > "%1\Resources\PSP\%%~ni.xml.gz"
@for %%i in (%1\Resources\PSP\Abilities\*.xml) do "%1\gzip" -c "%%i" > "%1\Resources\PSP\Abilities\%%~ni.xml.gz"
@for %%i in (%1\Resources\PSP\Items\*.xml) do "%1\gzip" -c "%%i" > "%1\Resources\PSP\Items\%%~ni.xml.gz"
@for %%i in (%1\Resources\PSP\bin\*.bin) do "%1\gzip" -c "%%i" > "%1\Resources\PSP\bin\%%~ni.bin.gz"

@for %%i in (%1\Resources\PSX-US\*.xml) do "%1\gzip" -c "%%i" > "%1\Resources\PSX-US\%%~ni.xml.gz"
@for %%i in (%1\Resources\PSX-US\Abilities\*.xml) do "%1\gzip" -c "%%i" > "%1\Resources\PSX-US\Abilities\%%~ni.xml.gz"
@for %%i in (%1\Resources\PSX-US\Items\*.xml) do "%1\gzip" -c "%%i" > "%1\Resources\PSX-US\Items\%%~ni.xml.gz"
@for %%i in (%1\Resources\PSX-US\bin\*.bin) do "%1\gzip" -c "%%i" > "%1\Resources\PSX-US\bin\%%~ni.bin.gz"
@for %%i in (%1\Resources\*.ENT) do "%1\gzip" -c "%%i" > "%1\Resources\%%~ni.ENT.gz"
@for %%i in (%1\Resources\*.xml) do "%1\gzip" -c "%%i" > "%1\Resources\%%~ni.xml.gz"