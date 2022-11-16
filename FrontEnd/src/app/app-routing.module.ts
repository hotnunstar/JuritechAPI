import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { HomeComponent } from "./views/home/home.component";
import { LoginComponent } from "./components/auth/login/login.component";
import { RegisterComponent } from "./components/auth/register/register.component";
import { ResetPasswordComponent } from "./components/auth/reset-password/reset-password.component";
import { GetProcessoComponent } from "./request/processo/get-processo/get-processo.component";
import { UpdateProcessoComponent } from "./request/processo/update-processo/update-processo.component";
import { GetTemaComponent } from "./request/tema/get-tema/get-tema.component";
import { GetTipoProcessoComponent } from "./request/tipo-processo/get-tipo-processo/get-tipo-processo.component";
import { GetArtigoComponent } from "./request/artigo/get-artigo/get-artigo.component";
import { CreateArtigoComponent } from "./request/artigo/create-artigo/create-artigo.component";
import { UpdateArtigoComponent } from "./request/artigo/update-artigo/update-artigo.component";
import { CreateProcessoComponent } from "./request/processo/create-processo/create-processo.component";
import { CreateTemaComponent } from "./request/tema/create-tema/create-tema.component";
import { CreateTipoProcessoComponent } from "./request/tipo-processo/create-tipo-processo/create-tipo-processo.component";
import { UpdateTipoProcessoComponent } from "./request/tipo-processo/update-tipo-processo/update-tipo-processo.component";
import { GetFaseProcessualComponent } from "./request/fase-processual/get-fase-processual/get-fase-processual.component";
import { UpdateFaseProcessualComponent } from "./request/fase-processual/update-fase-processual/update-fase-processual.component";
import { UpdateTemaComponent } from "./request/tema/update-tema/update-tema.component";
import { CreateFaseProcessualComponent } from "./request/fase-processual/create-fase-processual/create-fase-processual.component";
import { DeleteArtigoComponent } from "./request/artigo/delete-artigo/delete-artigo.component";
import { GetPrazoComponent } from "./request/prazo/get-prazo/get-prazo.component";
import { CreatePrazoComponent } from "./request/prazo/create-prazo/create-prazo.component";
import { DeletePrazoComponent } from "./request/prazo/delete-prazo/delete-prazo.component";

const routes: Routes = [
  
  // AUTENTICAÇÃO
  {
    path: "",
    component: LoginComponent,
  },
  {
    path: "login",
    component: LoginComponent,
  },
  {
    path: "registo",
    component: RegisterComponent,
  },
  {
    path: "recuperar-senha",
    component: ResetPasswordComponent,
  },
  {
    path: "inicio",
    component: HomeComponent,
  },

  // PROCESSOS
  {
    path: "get-processo",
    component: GetProcessoComponent,
  },

  {
    path: "criar-processo",
    component: CreateProcessoComponent ,
  },

  {
    path: "update-processo/:idUtilizador/:nrProcesso",
    component: UpdateProcessoComponent ,
  },

  // FASES PROCESSUAIS
  {
    path: "get-faseprocessual",
    component: GetFaseProcessualComponent ,
  },
  {
    path: "update-faseprocessual/:idUtilizador/:nrProcesso/:idEstado/:dataEntrada",
    component: UpdateFaseProcessualComponent ,
  },
  {
    path: "criar-faseprocessual",
    component: CreateFaseProcessualComponent ,
  },

  // TIPO DE PROCESSOS
  {
    path: "get-tipoprocesso",
    component: GetTipoProcessoComponent ,
  },

  {
    path: "criar-tipoprocesso",
    component: CreateTipoProcessoComponent ,
  },

  {
    path: "update-tipoprocesso/:idUtilizador/:id",
    component: UpdateTipoProcessoComponent ,
  },

  // ARTIGOS
  {
    path: "get-artigos",
    component: GetArtigoComponent ,
  },

  {
    path: "criar-artigo",
    component: CreateArtigoComponent ,
  },

  {
    path: "update-artigo/:idUtilizador/:idCodigo/:nrArtigo",
    component: UpdateArtigoComponent ,
  },

  {
    path: "apagar-artigo/:idUtilizador/:idCodigo/:nrArtigo",
    component: DeleteArtigoComponent ,
  },

  // TEMAS
  {
    path: "get-temas",
    component: GetTemaComponent ,
  },
  {
    path: "criar-tema",
    component: CreateTemaComponent ,
  },

  {
    path: "update-tema/:idUtilizador/:id",
    component: UpdateTemaComponent ,
  },

  // PRAZOS
  {
    path: "get-prazos",
    component: GetPrazoComponent ,
  },
  {
    path: "criar-prazo",
    component: CreatePrazoComponent ,
  },
  {
    path: "apagar-prazo/:idUtilizador/:nrProcesso/:idPrazoCodigo",
    component: DeletePrazoComponent ,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
