import { AnyAction, MiddlewareArray, ThunkMiddleware } from "@reduxjs/toolkit";
import { ToolkitStore } from "@reduxjs/toolkit/dist/configureStore";
import { createUser, getAllUsers, getUser, updateUser } from "../../redux/reducers/reducerMethods/userMethods";
import { createStore, RootState } from "../../redux/store";
import server from "../shared/server";

let store: ToolkitStore<RootState, AnyAction, MiddlewareArray<[ThunkMiddleware<RootState, AnyAction, undefined>]>>
beforeAll(() => {
    server.listen()
})
afterAll(() => {
    server.close()
})
beforeEach(() => {
    store = createStore();
})
describe("test category reducers", () => {
    test("initial state of the login reducer", () => {
        expect(store.getState().userReducer.length).toBe(0)
    }),
        test("should get all the users", async () => {
            await store.dispatch(getAllUsers())
            expect(store.getState().userReducer.length).toBe(3)
        }),
        test("should get single user", async () => {
            await store.dispatch(getUser(2))
            expect(store.getState().userReducer.length).toBe(1)
        }),
        test("should create user", async () => {
            const createUserObj = {
                name: "Nicolas",
                email: "nico@gmail.com",
                password: "1234",
                avatar: "https://api.lorem.space/image/face?w=640&h=480&r=867",
            }
            await store.dispatch(createUser({ user: createUserObj }))
            expect(store.getState().userReducer[0].email).toBe("nicoo@gmail.com")
        })
        test("should update user", async () => {
            await store.dispatch(getAllUsers())
            const updateuserObj = {
                id: 1,
                user: {
                    email: "johndimellow@mail.com",
                    name: "ShowmeChanged"
                }
            }
            await store.dispatch(updateUser(updateuserObj))
            //console.log(store.getState().userReducer)
        })
})
