import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductLayoutComponent } from './layout/product-layout.component';
import { AuthModule } from './modules/auth/auth.module';
import { BookModule } from './modules/book/book.module';
import { CartModule } from './modules/cart/cart.module';

const routes: Routes = [
    {
        path: 'book',
        component: ProductLayoutComponent,
        loadChildren: () =>
            BookModule
    },
    {
        path: 'cart',
        component: ProductLayoutComponent,
        loadChildren: () => 
            CartModule
        
    },
    {
        path: 'auth',
        component: ProductLayoutComponent,
        loadChildren: () => 
            AuthModule
        
    }
]

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule],
    providers: []
})
export class AppRoutingModule { }