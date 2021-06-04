let seuVotoPara = document.querySelector('.d-1-1 span');
let cargo = document.querySelector('.d-1-2 span');
let descricao = document.querySelector('.d-1-4');
let aviso = document.querySelector('.d-2');
let lateral = document.querySelector('.d-1-right');
let numeros = document.querySelector('.d-1-3');

let etapaAtual = 5;
let numero = '';
let votoBranco = false;
let votos = [];

async function comecarEtapa() {
    let etapa = await Etapas();

    let numeroHTML = '';
    numero = '';
    votoBranco = false;

    for (let i = 0; i < etapaAtual;i++) {
        if(i ===0) {
            numeroHTML += '<div class="numero pisca"></div>';
        } else{
            numeroHTML += '<div class="numero"></div>';
        }    
    }

    seuVotoPara.style.display = 'none';
    if (etapa.partido = 1) {
        etapa.partido = 'Vereador';
    } else {
        etapa.partido = 'Prefeito';

    }
    cargo.innerHTML = 'Vereador';

    descricao.innerHTML = '';
    aviso.style.display = 'none';
    lateral.innerHTML = '';
    numeros.innerHTML = numeroHTML;
}
async function atualizaInterface(){
    let etapa = await Etapas();
   
    let candidato = etapa.filter((item)=>{
        if(item.numero == numero) {
            return true;
        } else {
            return false;
        }
    });
    if(candidato.length > 0) {
        candidato = candidato[0];
        if (candidato.partido = 1) {
            candidato.partido = 'Vereador';
        } else {
            candidato.partido = 'Prefeito';

        }
        seuVotoPara.style.display = 'block';
        aviso.style.display = 'block';
        //descricao.innerHTML = 'Nome: ${candidato.nome}<br/>Partido: ${candidato.partido}';
        descricao.innerHTML = 'Nome: '+candidato.nome+'<br/>'+'Partido: '+candidato.partido;

        let fotosHTML = '';
        if (candidato.url.small) {
            fotosHTML += '<div class="d-1-image small"> <img src="' + candidato.url + '" alt="" />' + candidato.nome + '</div>';
            }else {
                //fotosHTML += '<div class="d-1-image"> <img src="Images/${candidato.fotos[i].url}" alt="" />${candidato.fotos[i].legenda}</div>';
                fotosHTML += '<div class="d-1-image"> <img src="Images/'+candidato.url+'" alt="" />'+candidato.legenda+'</div>';
            }
 
        

        lateral.innerHTML = fotosHTML;
    }else {
        seuVotoPara.style.display = 'block';
        aviso.style.display = 'block';
        descricao.innerHTML = '<div class="aviso--grande pisca">VOTO NULO</div>';
    }
}

function clicou(n) {
    let somNumeros = new Audio();
    somNumeros.src = "audios/numeros.mp3";
    somNumeros.play();

    let elNumero = document.querySelector('.numero.pisca');
    if(elNumero !== null) {
        elNumero.innerHTML = n;
        //numero = '${numero}${n}';
        numero = numero+n;

        //fazer com que o campo de número pisque e após preenchido passe para o proximo campo
        elNumero.classList.remove('pisca');
        if( elNumero.nextElementSibling !== null){
            elNumero.nextElementSibling.classList.add('pisca');
        } else {
            atualizaInterface();
        }
    }
} 
function branco() {
    numero === ''
    votoBranco = true;

    seuVotoPara.style.display = 'block';
    aviso.style.display = 'block';
    numeros.innerHTML = '';
    descricao.innerHTML = '<div class="aviso--grande pisca">VOTO EM BRANCO</div>';
    lateral.innerHTML = '';

    
}
function corrige() {
    let somCorrige = new Audio();
    somCorrige.src = "audios/corrige.mp3";
    somCorrige.play();
    comecarEtapa();
}
async function confirma() {
    let etapa = await Etapas();

    let votoConfirmado = false;
    let somConfirma = new Audio("audios/confirma.mp3");

    if (votoBranco === true) {
        votoConfirmado = true;
        somConfirma.play();

        votos.push({
            etapa: etapa.titulo,
            voto: 'branco'
        });
    }
    else
    {
               
        votoConfirmado = true;
        somConfirma.play();

        votos.push({
            etapa: etapa.titulo,
            voto: numero
        });

    
    }

    if(votoConfirmado) {
        if (etapa !== undefined) {
            etapaAtual = 2;
            comecarEtapa();
        } else {
            document.querySelector('.tela').innerHTML = '<div class="aviso--gigante pisca">FIM</div>';
            console.log(votos);
        }
    }
}

comecarEtapa();