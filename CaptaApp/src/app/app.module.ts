import { NgModule } from '@angular/core';
import { ToastrModule } from 'ngx-toastr';
import { AppRoutingModule } from './app-routing.module';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { TooltipModule, BsDropdownModule, ModalModule } from 'ngx-bootstrap';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { TimeService } from './_services/time.service';
import { JogadoreService } from './_services/jogadore.service';
import { HabilidadeService } from './_services/habilidade.service';

import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { UserComponent } from './User/User.component';
import { TimesComponent } from './times/times.component';
import { AuthInterceptor } from './auth/auth.interceptor';
import { LoginComponent } from './user/login/login.component';
import { JogadoresComponent } from './jogadores/jogadores.component';
import { HabilidadesComponent } from './habilidades/habilidades.component';
import { RegistrationComponent } from './user/registration/registration.component';

@NgModule({
   declarations: [
      AppComponent,
      NavComponent,
      UserComponent,
      TimesComponent,
      LoginComponent,
      JogadoresComponent,
      HabilidadesComponent,
      RegistrationComponent
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
      BsDropdownModule.forRoot()
   ],
   providers: [
      TimeService,
      JogadoreService,
      HabilidadeService,
      {
        provide: HTTP_INTERCEPTORS,
        useClass: AuthInterceptor,
        multi: true
      }
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
