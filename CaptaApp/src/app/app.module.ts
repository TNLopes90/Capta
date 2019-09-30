import { NgModule } from '@angular/core';
import { ToastrModule } from 'ngx-toastr';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TooltipModule, BsDropdownModule, ModalModule } from 'ngx-bootstrap';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { TimeService } from './_services/time.service';
import { JogadoreService } from './_services/jogadore.service';
import { HabilidadeService } from './_services/habilidade.service';

import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { TimesComponent } from './times/times.component';
import { JogadoresComponent } from './jogadores/jogadores.component';
import { HabilidadesComponent } from './habilidades/habilidades.component';

@NgModule({
   declarations: [
      AppComponent,
      NavComponent,
      TimesComponent,
      JogadoresComponent,
      HabilidadesComponent
   ],
   imports: [
     FormsModule,
     BrowserModule,
     HttpClientModule,
     AppRoutingModule,
     ReactiveFormsModule,
     ModalModule.forRoot(),
     ToastrModule.forRoot(),
     TooltipModule.forRoot(),
     BrowserAnimationsModule,
     BsDropdownModule.forRoot(),
   ],
   providers: [
     TimeService,
     JogadoreService,
     HabilidadeService

   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
