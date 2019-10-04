import { NgModule } from '@angular/core';
import { AuthGuard } from './auth/auth.guard';
import { UserComponent } from './User/User.component';
import { Routes, RouterModule } from '@angular/router';
import { TimesComponent } from './times/times.component';
import { LoginComponent } from './user/login/login.component';
import { JogadoresComponent } from './jogadores/jogadores.component';
import { HabilidadesComponent } from './habilidades/habilidades.component';
import { RegistrationComponent } from './user/registration/registration.component';


const routes: Routes = [
  { path: 'user', component: UserComponent,
  children: [
    { path: 'login', component: LoginComponent },
    { path: 'registration', component: RegistrationComponent },
  ] },

  { path: '', component: TimesComponent, canActivate: [AuthGuard] },
  { path: '**', component: TimesComponent, canActivate: [AuthGuard] },
  { path: 'times', component: TimesComponent, canActivate: [AuthGuard] },
  { path: 'jogadores', component: JogadoresComponent, canActivate: [AuthGuard] },
  { path: 'habilidades', component: HabilidadesComponent, canActivate: [AuthGuard] },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
