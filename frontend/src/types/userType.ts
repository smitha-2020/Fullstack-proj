export interface IUser{
    id:number,
    user:Partial<IAuthenticUser>
}
export interface CreateUser {
    user:Partial<IAuthenticUser>
}
export interface IAuthenticUser {
    id: number,
    avatar: string,
    email: string,
    password: string,
    name: string,
    role: string
}
export interface IRegisteredUser {
    access_token: string,
    user: IAuthenticUser,
    isRegistered: boolean,
    isLogin: boolean,
    isLoading:boolean
}
export type Inputs = {
    name: string,
    email: string,
    password: string,
    repassword?: string,
    avatar: FileList
}
export interface ILoginData {
    email: string,
    password: string
}

