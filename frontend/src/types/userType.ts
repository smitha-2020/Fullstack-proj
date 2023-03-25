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
    accessToken: string,
    user: IAuthenticUser,
    isRegistered: boolean,
    isLogin: boolean,
    isLoading:boolean
}
export type Inputs = {
    username: string,
    firstname: string,
    lastname: string,
    email: string,
    password: string,
    confirmpassword?: string,
    avatar: FileList
}
export interface ILoginData {
    email: string,
    password: string
}
export interface IUserResponse {
    firstName: string,
    lastName: string,
    username: string,
    email: string,
    avatar: string
}

