import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { AppRoutingModule } from "./app-routing.module";
import { AppComponent } from "./app.component";

import { FullCalendarModule } from '@fullcalendar/angular';
import dayGridPlugin from '@fullcalendar/daygrid';

import { LoginComponent } from "./components/auth/login/login.component";
import { RegisterComponent } from "./components/auth/register/register.component";
import { HomeComponent } from "./views/home/home.component";
import { FooterComponent } from "./components/template/footer/footer.component";
import { NavComponent } from "./components/template/nav/nav.component";
import { ResetPasswordComponent } from "./components/auth/reset-password/reset-password.component";
import { HttpClientModule } from "@angular/common/http";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { UsersApiComponent } from "./components/auth/users-api/users-api.component";
import { GetProcessoComponent } from "./request/processo/get-processo/get-processo.component";
import { NavpagesComponent } from "./components/template/navpages/navpages.component";
import { GetTemaComponent } from "./request/tema/get-tema/get-tema.component";
import { UpdateArtigoComponent } from "./request/artigo/update-artigo/update-artigo.component";
import { UpdateTemaComponent } from "./request/tema/update-tema/update-tema.component";
import { CreateArtigoComponent } from "./request/artigo/create-artigo/create-artigo.component";
import { GetArtigoComponent } from "./request/artigo/get-artigo/get-artigo.component";
import { GetEstadoComponent } from "./request/gets/get-estado/get-estado.component";
import { GetFaseProcessualComponent } from "./request/fase-processual/get-fase-processual/get-fase-processual.component";
import { UpdateFaseProcessualComponent } from "./request/fase-processual/update-fase-processual/update-fase-processual.component";

import { CreateTemaComponent } from "./request/tema/create-tema/create-tema.component";
import { UpdateTipoProcessoComponent } from "./request/tipo-processo/update-tipo-processo/update-tipo-processo.component";
import { CreateTipoProcessoComponent } from "./request/tipo-processo/create-tipo-processo/create-tipo-processo.component";
import { ProcessoApiComponent } from "./request/processo/processo-api/processo-api.component";
import { FontAwesomeModule } from "@fortawesome/angular-fontawesome";
import { PopupComponent } from './components/popup/popup.component';
import { FaIconLibrary } from '@fortawesome/angular-fontawesome'; //Imports para icons font-awesome
import { faStar as farStar } from '@fortawesome/free-regular-svg-icons';
import { faStar as fasStar } from '@fortawesome/free-solid-svg-icons';
import { SidebarComponent } from './components/template/sidebar/sidebar.component';
import { NgbModule } from "@ng-bootstrap/ng-bootstrap";

import { TemaApiComponent } from './request/tema/tema-api/tema-api.component';
import { GetTipoProcessoComponent } from "./request/tipo-processo/get-tipo-processo/get-tipo-processo.component";
import { DeleteArtigoComponent } from "./request/artigo/delete-artigo/delete-artigo.component";
import { CreateProcessoComponent } from "./request/processo/create-processo/create-processo.component";
import { UpdateProcessoComponent } from "./request/processo/update-processo/update-processo.component";
import { CreateFaseProcessualComponent } from "./request/fase-processual/create-fase-processual/create-fase-processual.component";
import { GetPrazoComponent } from "./request/prazo/get-prazo/get-prazo.component";
import { CreatePrazoComponent } from "./request/prazo/create-prazo/create-prazo.component";
import { UpdatePrazoComponent } from "./request/prazo/update-prazo/update-prazo.component";
import { DeletePrazoComponent } from "./request/prazo/delete-prazo/delete-prazo.component";
import { GetPrazoCodigoComponent } from "./request/gets/get-prazo-codigo/get-prazo-codigo.component";
import { GetTipoPrazoComponent } from "./request/gets/get-tipo-prazo/get-tipo-prazo.component";

FullCalendarModule.registerPlugins([
  dayGridPlugin,
])

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    HomeComponent,
    FooterComponent,
    NavComponent,
    NavpagesComponent,
    ResetPasswordComponent,
    UsersApiComponent,

    CreateTipoProcessoComponent,
    CreateArtigoComponent,
    CreateTemaComponent,
    CreateProcessoComponent,
    CreateFaseProcessualComponent,
    CreatePrazoComponent,

    GetArtigoComponent,
    GetEstadoComponent,
    GetProcessoComponent,
    GetTemaComponent,
    GetFaseProcessualComponent,
    GetPrazoComponent,
    GetPrazoCodigoComponent,
    GetTipoPrazoComponent,
    GetTipoProcessoComponent,

    UpdateFaseProcessualComponent,
    UpdateProcessoComponent,
    UpdateTipoProcessoComponent,
    UpdateArtigoComponent,
    UpdateTemaComponent,
    UpdatePrazoComponent,

    ProcessoApiComponent,
    PopupComponent,
    SidebarComponent,
    TemaApiComponent,
    DeleteArtigoComponent,
    DeletePrazoComponent, 
    
  ],
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule, 
    HttpClientModule, 
    FontAwesomeModule,
    NgbModule,
    ReactiveFormsModule,
    FullCalendarModule
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {
  constructor(library: FaIconLibrary) {
    library.addIcons(fasStar, farStar);
  }
}
