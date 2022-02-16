import axios from "axios";

export const LerConteudoDaImagem = async (formData) => {

    let resultado;

    let retorno = await axios({
        method: 'POST',
        url : 'https://ocr-equipamentosT.cognitiveservices.azure.com/vision/v3.2/ocr?language=unk&detectOrientation=true&model-version=latest',
        data : formData,
        headers : {
            "Content-Type" : "multipart/form-data",
            "Ocp-Apim-Subscription-Key" : "6fa4d39fa67d4fc6a246616e99befa8e"
        }
    })
    .then(response => {
        console.log(response.data)
        resultado = LerJSON(response.data)
    })
    .catch(erro => {console.log(erro)})

    return resultado;
}

export const LerJSON = (obj) => {

    let resultado

    obj.regions.forEach(regions => {
        regions.lines.forEach(lines => {
            lines.words.forEach(words => {
                if (words.text[0] === "1" && words.text[1] === "2"){
                    resultado = words.text
                }
            })
        })
    });

    console.log(resultado)

    return resultado;
}